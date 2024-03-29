﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SkulyRepack
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var aInfo = new FileInfo(@"MySQL\bin\mysqld.exe");

            if (aInfo.Exists)
            {
                var sqlcheck1 = "mysqld";
                var sqlcheck2 = Process.GetProcessesByName(sqlcheck1);
                if ((sqlcheck2.Length == 0))
                {
                    var mysql = new Process();
                    mysql.StartInfo.FileName = @"MySQL\bin\mysqld.exe";
                    mysql.StartInfo.Arguments = "--console";
                    mysql.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    mysql.Start();
                    Thread.Sleep(4000);

                    var createText = "SET @REALMNAME = \"" + textBox1.Text + "\";";
                    Directory.CreateDirectory(@"updater\launcher\sql\RealmName");
                    File.WriteAllText(@"updater\launcher\sql\RealmName\RealmName.sql", createText, Encoding.UTF8);

                    var text = System.IO.File.ReadAllText(@"updater\launcher\sql\RealmName\RealmName2.sql");
                    var appendText = text;
                    File.AppendAllText(@"updater\launcher\sql\RealmName\RealmName.sql", appendText);


                    var spawntime = new Process();
                    var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root auth < " + @"updater\launcher\sql\RealmName\RealmName.sql";
                    spawntime.StartInfo.FileName = "cmd.exe";
                    spawntime.StartInfo.Arguments = spawntimestring;
                    spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    spawntime.Start();
                    spawntime.WaitForExit();

                    DialogResult d;
                    d = MessageBox.Show("Realm Name was changed to " + textBox1.Text + ".", "Realm Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
                    {
                        Close();
                    }

                }
                else
                {

                    var createText = "SET @REALMNAME = \"" + textBox1.Text + "\";";
                    Directory.CreateDirectory(@"updater\launcher\sql\RealmName");
                    File.WriteAllText(@"updater\launcher\sql\RealmName\RealmName.sql", createText, Encoding.UTF8);

                    var text = System.IO.File.ReadAllText(@"updater\launcher\sql\RealmName\RealmName2.sql");
                    var appendText = text;
                    File.AppendAllText(@"updater\launcher\sql\RealmName\RealmName.sql", appendText);


                    var spawntime = new Process();
                    var spawntimestring = "/C " + @"MySQL\bin\mysql -u root --password=root auth < " + @"updater\launcher\sql\RealmName\RealmName.sql";
                    spawntime.StartInfo.FileName = "cmd.exe";
                    spawntime.StartInfo.Arguments = spawntimestring;
                    spawntime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    spawntime.Start();
                    spawntime.WaitForExit();

                    DialogResult d;
                    d = MessageBox.Show("Realm Name was changed to " + textBox1.Text + ".", "Realm Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
                    {
                        Close();
                    }
                }

            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Make sure this program is in the repack folder.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    Close();
                }

            }
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
