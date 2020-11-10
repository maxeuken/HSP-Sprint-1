namespace Zahnraddimensionierungsprogramm.GruppeJ
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.zahnradWerteTabelleDataSet = new Zahnraddimensionierungsprogramm.GruppeJ.ZahnradWerteTabelleDataSet();
            this.zahnradwerteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahnradwerteTableAdapter = new Zahnraddimensionierungsprogramm.GruppeJ.ZahnradWerteTabelleDataSetTableAdapters.ZahnradwerteTableAdapter();
            this.tableAdapterManager = new Zahnraddimensionierungsprogramm.GruppeJ.ZahnradWerteTabelleDataSetTableAdapters.TableAdapterManager();
            this.zahnradwerteBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.zahnradwerteBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.zahnradwerteDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradWerteTabelleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradwerteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradwerteBindingNavigator)).BeginInit();
            this.zahnradwerteBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradwerteDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // zahnradWerteTabelleDataSet
            // 
            this.zahnradWerteTabelleDataSet.DataSetName = "ZahnradWerteTabelleDataSet";
            this.zahnradWerteTabelleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // zahnradwerteBindingSource
            // 
            this.zahnradwerteBindingSource.DataMember = "Zahnradwerte";
            this.zahnradwerteBindingSource.DataSource = this.zahnradWerteTabelleDataSet;
            // 
            // zahnradwerteTableAdapter
            // 
            this.zahnradwerteTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Zahnraddimensionierungsprogramm.GruppeJ.ZahnradWerteTabelleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // zahnradwerteBindingNavigator
            // 
            this.zahnradwerteBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.zahnradwerteBindingNavigator.BindingSource = this.zahnradwerteBindingSource;
            this.zahnradwerteBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.zahnradwerteBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.zahnradwerteBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.zahnradwerteBindingNavigatorSaveItem});
            this.zahnradwerteBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.zahnradwerteBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.zahnradwerteBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.zahnradwerteBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.zahnradwerteBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.zahnradwerteBindingNavigator.Name = "zahnradwerteBindingNavigator";
            this.zahnradwerteBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.zahnradwerteBindingNavigator.Size = new System.Drawing.Size(800, 25);
            this.zahnradwerteBindingNavigator.TabIndex = 0;
            this.zahnradwerteBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Erste verschieben";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Vorherige verschieben";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuelle Position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 15);
            this.bindingNavigatorCountItem.Text = "von {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente.";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Nächste verschieben";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Letzte verschieben";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Neu hinzufügen";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Löschen";
            // 
            // zahnradwerteBindingNavigatorSaveItem
            // 
            this.zahnradwerteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zahnradwerteBindingNavigatorSaveItem.Enabled = false;
            this.zahnradwerteBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("zahnradwerteBindingNavigatorSaveItem.Image")));
            this.zahnradwerteBindingNavigatorSaveItem.Name = "zahnradwerteBindingNavigatorSaveItem";
            this.zahnradwerteBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 20);
            this.zahnradwerteBindingNavigatorSaveItem.Text = "Daten speichern";
            // 
            // zahnradwerteDataGridView
            // 
            this.zahnradwerteDataGridView.AutoGenerateColumns = false;
            this.zahnradwerteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zahnradwerteDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.zahnradwerteDataGridView.DataSource = this.zahnradwerteBindingSource;
            this.zahnradwerteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zahnradwerteDataGridView.Location = new System.Drawing.Point(0, 25);
            this.zahnradwerteDataGridView.Name = "zahnradwerteDataGridView";
            this.zahnradwerteDataGridView.Size = new System.Drawing.Size(800, 425);
            this.zahnradwerteDataGridView.TabIndex = 1;
            this.zahnradwerteDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.zahnradwerteDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Art";
            this.dataGridViewTextBoxColumn1.HeaderText = "Art";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Bezeichnung";
            this.dataGridViewTextBoxColumn2.HeaderText = "Bezeichnung";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Flankenhärte";
            this.dataGridViewTextBoxColumn3.HeaderText = "Flankenhärte";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Zahnfußdauerfestigkeit";
            this.dataGridViewTextBoxColumn4.HeaderText = "Zahnfußdauerfestigkeit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Zahnflankendauerfestigkeit";
            this.dataGridViewTextBoxColumn5.HeaderText = "Zahnflankendauerfestigkeit";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zahnradwerteDataGridView);
            this.Controls.Add(this.zahnradwerteBindingNavigator);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zahnradWerteTabelleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradwerteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradwerteBindingNavigator)).EndInit();
            this.zahnradwerteBindingNavigator.ResumeLayout(false);
            this.zahnradwerteBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zahnradwerteDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZahnradWerteTabelleDataSet zahnradWerteTabelleDataSet;
        private System.Windows.Forms.BindingSource zahnradwerteBindingSource;
        private ZahnradWerteTabelleDataSetTableAdapters.ZahnradwerteTableAdapter zahnradwerteTableAdapter;
        private ZahnradWerteTabelleDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator zahnradwerteBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton zahnradwerteBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView zahnradwerteDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}