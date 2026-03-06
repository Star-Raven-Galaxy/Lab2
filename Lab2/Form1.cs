using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Lab2.Models;
using Lab2.Services;
using System.Diagnostics;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private readonly ProcessInfoService _processService = new ProcessInfoService();
        private readonly ProcessPriorityService _priorityService = new ProcessPriorityService();
        private BindingList<ProcessInfo> _processList;
        private CancellationTokenSource _cts;
        private AffinityService _affinityService = new AffinityService();
        private int _currentProcessId = -1;
        private int _coreCount;
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            StartBackgroundUpdate();
            dgvProcesses.SelectionChanged += dgvProcesses_SelectionChanged;
        }
        private void InitializeComboBox()
        {
            cmbPriority.DataSource = Enum.GetValues(typeof(ProcessPriorityClass));
        }

        private void dgvProcesses_SelectionChanged(object sender, EventArgs e)
        {
  
         
                if (dgvProcesses.CurrentRow == null)
                    return;

                ProcessInfo selected =
                    dgvProcesses.CurrentRow.DataBoundItem as ProcessInfo;

                if (selected == null)
                    return;

                LoadAffinity(selected.Id);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void StartBackgroundUpdate()
        {
            _cts = new CancellationTokenSource();

            Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    var processes = _processService.GetAllProcesses();

                    Invoke(new Action(() =>
                    {
                        _processList = new BindingList<ProcessInfo>(processes);
                        dgvProcesses.DataSource = _processList;
                    }));

                    await Task.Delay(2000);
                }

            }, _cts.Token);
        }

        private void btnSetPriority_Click(object sender, EventArgs e)
        {
            if (dgvProcesses.CurrentRow == null) return;

            var selectedProcess = dgvProcesses.CurrentRow.DataBoundItem as ProcessInfo;
            if (selectedProcess == null) return;

            var selectedPriority = (ProcessPriorityClass)cmbPriority.SelectedItem;

            bool success = _priorityService.SetProcessPriority(selectedProcess.Id, selectedPriority);

            if (success)
            {
                lblCurrentPriority.Text = $"Текущий приоритет: {selectedPriority}";
            }
        }

       
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();
            base.OnFormClosing(e);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void LoadAffinity(int processId)
        {
            try
            {
                flowCores.Controls.Clear();

                _coreCount = _affinityService.GetCoreCount();
                _currentProcessId = processId;

                IntPtr mask = _affinityService.GetAffinity(processId);

                for (int i = 0; i < _coreCount; i++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = "CPU " + i;
                    cb.Tag = i;
                    cb.Checked = AffinityHelper.IsCoreEnabled(mask, i);

                    cb.CheckedChanged += CoreCheckChanged;

                    flowCores.Controls.Add(cb);
                }

                lblBinaryMask.Text = "Binary: " + _affinityService.ToBinary(mask);
                lblHexMask.Text = "Hex: " + _affinityService.ToHex(mask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void CoreCheckChanged(object sender, EventArgs e)
        {
            UpdateMaskPreview();
        }
        private void UpdateMaskPreview()
        {
            bool[] cores = new bool[_coreCount];

            foreach (CheckBox cb in flowCores.Controls)
            {
                int index = (int)cb.Tag;
                cores[index] = cb.Checked;
            }
           

            IntPtr newMask = AffinityHelper.SetCoreMask(cores);

            lblBinaryMask.Text = "Binary: " + _affinityService.ToBinary(newMask);
            lblHexMask.Text = "Hex: " + _affinityService.ToHex(newMask);
        }

        private void btnApplyAffinity_Click(object sender, EventArgs e)
        {
            if (_currentProcessId == -1)
                return;

            try
            {
                bool[] cores = new bool[_coreCount];

                foreach (CheckBox cb in flowCores.Controls)
                {
                    int index = (int)cb.Tag;
                    cores[index] = cb.Checked;
                }
                if (!cores.Any(c => c))
                {
                    MessageBox.Show("Нужно выбрать хотя бы одно ядро!");
                    return;
                }

                IntPtr newMask = AffinityHelper.SetCoreMask(cores);

                _affinityService.SetAffinity(_currentProcessId, newMask);

                MessageBox.Show("Affinity успешно изменена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
