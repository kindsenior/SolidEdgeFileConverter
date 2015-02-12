using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices; // for com
using IWshRuntimeLibrary; // for shortcuts, needs windows script host object model

using System.Xml;
using System.IO;
using Google.GData.Client;
using Google.GData.Spreadsheets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool debug;
        public Form1()
        {
            InitializeComponent();
#if DEBUG
            debug = true;
#else
            debug = false;
#endif
        }

        private void ButtonToPDF_Click(object sender, EventArgs e)
        {
            if (!IsSolidEdge()) return;

            progressBar1.Maximum = ListboxFiles.Items.Count;
            progressBar1.Value = 0;
            foreach (object item in ListboxFiles.Items)
            {
                DraftSaveAs(item.ToString(), TextboxDestDir.Text, "pdf");
                progressBar1.Value++;
            }

            MessageBox.Show("converted.");
        }

        private void ButtonToDXF_Click(object sender, EventArgs e)
        {
            if (!IsSolidEdge()) return;

            progressBar1.Maximum = ListboxFiles.Items.Count;
            progressBar1.Value = 0;
            foreach (object item in ListboxFiles.Items)
            {
                DraftSaveAs(item.ToString(), TextboxDestDir.Text, "dxf");
                progressBar1.Value++;
            }

            MessageBox.Show("converted.");
        }

        private void ButtonToPDFandDXF_Click(object sender, EventArgs e)
        {
            if (!IsSolidEdge()) return;

            progressBar1.Maximum = ListboxFiles.Items.Count * 2;
            progressBar1.Value = 0;
            foreach (object item in ListboxFiles.Items)
            {
                DraftSaveAs(item.ToString(), TextboxDestDir.Text, "pdf");
                progressBar1.Value++;
                DraftSaveAs(item.ToString(), TextboxDestDir.Text, "dxf");
                progressBar1.Value++;
            }

            MessageBox.Show("converted.");
        }

        private void ButtonToIGES_Click(object sender, EventArgs e)
        {
            if (!IsSolidEdge()) return;

            progressBar1.Maximum = ListboxFiles.Items.Count;
            progressBar1.Value = 0;
            foreach (object item in ListboxFiles.Items)
            {
                PartinDraftSaveAs(item.ToString(), TextboxDestDir.Text, "iges");
                progressBar1.Value++;
            }

            MessageBox.Show("converted.");
        }

        private void ButtonToSTEP_Click(object sender, EventArgs e)
        {
            if (!IsSolidEdge()) return;

            progressBar1.Maximum = ListboxFiles.Items.Count;
            progressBar1.Value = 0;
            foreach (object item in ListboxFiles.Items)
            {
                PartinDraftSaveAs(item.ToString(), TextboxDestDir.Text, "step");
                progressBar1.Value++;
            }

            MessageBox.Show("converted.");
        }

        private bool IsSolidEdge()
        {
            SolidEdgeFramework.Application app = null;
            bool ret = false;

            try{
                //connect to solidedge instance
                app = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                ret = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("SolidEdgeが見つかりません");
            }
            finally{
                if (app != null)
                {
                    Marshal.ReleaseComObject(app);
                    app = null;
                }
            }
            return ret;
        }


        private bool DraftSaveAs(string filename, string destdir, string ext)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeDraft.DraftDocument draft = null;
            bool IsOverwrite = CheckboxIsOverwrite.Checked;
            bool ret = false;

            try
            {
                //check if the file exists
                if (!System.IO.File.Exists(filename))
                    throw (new System.Exception("file not found: " + filename));

                //check if the directory
                if (!System.IO.Directory.Exists(destdir))
                    throw (new System.Exception("directory not found: " + destdir));

                //check if the file ext is dft
                if (System.IO.Path.GetExtension(filename) != ".dft")
                    throw (new System.Exception("This is not a Draft file: " + filename));
                
                //connect to solidedge instance
                application = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                documents = application.Documents;
                if (debug) MessageBox.Show("solid edge found");

                if (debug) MessageBox.Show("open draft");
                //draft = (SolidEdgeDraft.DraftDocument)documents.Add("SolidEdge.DraftDocument", Missing.Value);
                draft = (SolidEdgeDraft.DraftDocument)documents.Open(filename);


                string outfile = destdir + "\\" + System.IO.Path.GetFileNameWithoutExtension(filename) + "." + ext;
                if (debug) MessageBox.Show("filename: " + outfile);

                if (IsOverwrite)
                {
                    //delete exist file
                    if (debug) MessageBox.Show("delete file");
                    System.IO.File.Delete(outfile);
                }

                if (debug) MessageBox.Show("save file");
                draft.SaveAs(outfile);

                if (debug) MessageBox.Show("close draft");
                draft.Close(false);

                ret = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (draft != null)
                {
                    Marshal.ReleaseComObject(draft);
                    draft = null;
                }
                if (documents != null)
                {
                    Marshal.ReleaseComObject(documents);
                    documents = null;
                }
                if (application != null)
                {
                    Marshal.ReleaseComObject(application);
                    application = null;
                }
            }
            return ret;
            
        }

        private bool PartinDraftSaveAs(string filename, string destdir, string ext)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeDraft.DraftDocument draft = null;
            SolidEdgeDraft.ModelLinks modellinks = null;
            SolidEdgePart.PartDocument part = null;
            SolidEdgePart.SheetMetalDocument sheetmetal = null;
            bool IsOverwrite = CheckboxIsOverwrite.Checked;
            bool ret = false;

            try
            {
                //check if the file exists
                if (!System.IO.File.Exists(filename))
                    throw (new System.Exception("file not found: " + filename));

                //check if the directory
                if (!System.IO.Directory.Exists(destdir))
                    throw (new System.Exception("directory not found: " + destdir));

                //check if the file ext is dft
                if (System.IO.Path.GetExtension(filename) != ".dft")
                    throw (new System.Exception("This is not a Draft file: " + filename));

                //connect to solidedge instance
                application = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                documents = application.Documents;
                if (debug) MessageBox.Show("solid edge found");

                if (debug) MessageBox.Show("open draft");
                //draft = (SolidEdgeDraft.DraftDocument)documents.Add("SolidEdge.DraftDocument", Missing.Value);
                draft = (SolidEdgeDraft.DraftDocument)documents.Open(filename);

                modellinks = draft.ModelLinks;

                for (int i = 1; i <= modellinks.Count; i++)
                {
                    string partfilename = modellinks.Item(i).FileName;
                    if (debug) MessageBox.Show(partfilename);

                    //check if the file is a part or sheetmetal file
                    string filetype = System.IO.Path.GetExtension(partfilename);
                    if (filetype == ".par") {
                        if (debug) MessageBox.Show("open part");
                        part = (SolidEdgePart.PartDocument)documents.Open(partfilename);
                    
                        string outfile = destdir + "\\" + System.IO.Path.GetFileNameWithoutExtension(filename) + "." + ext;
                        if (debug) MessageBox.Show("filename: " + outfile);
                    
                        if (IsOverwrite)
                        {
                            //delete exist file
                            if (debug) MessageBox.Show("delete file");
                            System.IO.File.Delete(outfile);
                        }

                        if (debug) MessageBox.Show("save file");
                        part.SaveAs(outfile);

                        if (debug) MessageBox.Show("close part");
                        part.Close(false);
                        ret = true;
                        break;
                    }
                    else if (filetype == ".psm")
                    {
                        if (debug) MessageBox.Show("open sheetmetal");
                        sheetmetal = (SolidEdgePart.SheetMetalDocument)documents.Open(partfilename);

                        string outfile = destdir + "\\" + System.IO.Path.GetFileNameWithoutExtension(filename) + "." + ext;
                        if (debug) MessageBox.Show("filename: " + outfile);

                        if (IsOverwrite)
                        {
                            //delete exist file
                            if (debug) MessageBox.Show("delete file");
                            System.IO.File.Delete(outfile);
                        }

                        if (debug) MessageBox.Show("save file");
                        sheetmetal.SaveAs(outfile);

                        if (debug) MessageBox.Show("close sheetmetal");
                        sheetmetal.Close(false);
                        ret = true;
                        break;
                    }
                }

                if (debug) MessageBox.Show("close draft");
                draft.Close(false);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sheetmetal != null)
                {
                    Marshal.ReleaseComObject(sheetmetal);
                    sheetmetal = null;
                }
                if (part != null)
                {
                    Marshal.ReleaseComObject(part);
                    part = null;
                }
                if (modellinks != null)
                {
                    Marshal.ReleaseComObject(modellinks);
                    modellinks = null;
                }
                if (draft != null)
                {
                    Marshal.ReleaseComObject(draft);
                    draft = null;
                }
                if (documents != null)
                {
                    Marshal.ReleaseComObject(documents);
                    documents = null;
                }
                if (application != null)
                {
                    Marshal.ReleaseComObject(application);
                    application = null;
                }
            }
            return ret;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonAddDraft_Click(object sender, EventArgs e)
        {
            // OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "ドラフトを追加";
            dialog.Filter = "SolidEdge ドラフト|*.dft";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in dialog.FileNames)
                {
                    //MessageBox.Show(filename);
                    ListboxFiles.Items.Add(filename);
                }
            }
            dialog.Dispose();
        }

        private void ButtonRemoveDraft_Click(object sender, EventArgs e)
        {
            while (ListboxFiles.SelectedItems.Count != 0)
                ListboxFiles.Items.RemoveAt(ListboxFiles.SelectedIndices[0]);
        }

        private void ButtonRemoveAllDrafts_Click(object sender, EventArgs e)
        {
            ListboxFiles.Items.Clear();
        }

        private void ButtonSelectDestDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.ShowNewFolderButton = true;
            dialog.Description = "出力先フォルダの選択";
            dialog.SelectedPath = TextboxDestDir.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextboxDestDir.Text = dialog.SelectedPath;
            }
        }


        private void ListboxFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private string ResolveShorcut(string filename)
        {

            WshShellClass shell = new WshShellClass();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(filename);
            return shortcut.TargetPath;
        }

        private void ListboxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                string ext = System.IO.Path.GetExtension(s[i]);
                if (ext == ".dft")
                {
                    ListboxFiles.Items.Add(s[i]);
                }
                else if (ext == ".lnk")
                {
                    string filename = ResolveShorcut(s[i]);
                    if (System.IO.Path.GetExtension(filename) == ".dft")
                    {
                        ListboxFiles.Items.Add(filename);
                    }
                }
            }
        }

        private void TextboxDestDir_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void TextboxDestDir_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (s.Length > 0)
            {
                if (debug) MessageBox.Show(s[0]);
                // check if it is a directory
                if (System.IO.Directory.Exists(s[0]))
                {
                    TextboxDestDir.Text = s[0];
                }
                else
                {
                    TextboxDestDir.Text = System.IO.Path.GetDirectoryName(s[0]);
                }
            }
        }

        private void ButtonAutoAddDrafts_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hoge");
            //ListboxFiles.Items.Add("\\\\andromeda\\share1\\STARO\\CAD\\JAXON1\\common_parts\\harmonic\\CSD25\\dft\\CSD25-cap.dft");
            // ListboxFiles.Items.Add(TextboxAutoLoadSetting.Text);
            GetPartsPath();
        }

        private void GetPartsPath()
        {
            //GetPartsPathFromGDrive();
            GetPartsPathFromXml();
        }

        private void GetPartsPathFromXml()
        {
            //if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            //string fn = "C:\\Users\\k-kojima\\Google ドライブ\\Documents\\JSK\\STARO\\test.xml"; //ロードするpartファイルの一覧を書いたxml
            string fn = TextboxAutoLoadSetting.Text; //ロードするpartファイルの一覧を書いたxml
            //textBox1.Text = fn;
            if (System.IO.File.Exists(fn))
            {
                //MessageBox.Show("open "+fn);
                XmlTextReader reader = null;
                try
                {
                    reader = new XmlTextReader(fn);
                    //ストリームからノードを読み取る
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.LocalName)
                            {
                                case "Cell":
                                    reader.Read();
                                    //MessageBox.Show(reader.ReadString());
                                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "Data")
                                    {
                                        ListboxFiles.Items.Add(reader.ReadString());
                                    }
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        private void GetPartsPathFromGDrive()
        {
            string CLIENT_ID = "1006233954353-1cauii1ksqvmip6kttlt2h9ku6hhpa4o.apps.googleusercontent.com";
            string CLIENT_SECRET = "vhA55KV3ZQTVKbbKVS5z41pi";
            string SCOPE = "https://www.googleapis.com/auth/drive";
            string REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

            OAuth2Parameters parameters = new OAuth2Parameters();
            parameters.ClientId = CLIENT_ID;
            parameters.ClientSecret = CLIENT_SECRET;
            parameters.RedirectUri = REDIRECT_URI;
            parameters.Scope = SCOPE;

            string authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
            Console.WriteLine(authorizationUrl);
            Console.WriteLine("Please visit the URL above to authorize your OAuth request token.  Once that is complete, type in your access code to continue...");
            //parameters.AccessCode = Console.ReadLine();
            parameters.AccessCode = "4/cJEyyVoq1229HtbbOfBqXjsegoz5k53-6-RL4gemyUE.UoWrJm537xcYBrG_bnfDxpIASUjxlgI";
            
            OAuthUtil.GetAccessToken(parameters);
            string accessToken = parameters.AccessToken;
            Console.WriteLine("OAuth Access Token: " + accessToken);

            GOAuth2RequestFactory requestFactory = new GOAuth2RequestFactory(null, "MySpreadsheetIntegration-v1", parameters);
            SpreadsheetsService service = new SpreadsheetsService("MySpreadsheetIntegration-v1");
            service.RequestFactory = requestFactory;

            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = service.Query(query);
            foreach (SpreadsheetEntry entry in feed.Entries)
            {
                // Print the title of this spreadsheet to the screen
                Console.WriteLine(entry.Title.Text);
            }

        }

        private void TextboxAutoLoadSetting_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (s.Length > 0)
            {
                if (debug) MessageBox.Show(s[0]);
                string ext = System.IO.Path.GetExtension(s[0]);
                if (ext == ".xml")
                {
                    TextboxAutoLoadSetting.Text = s[0];
                }
                else if (ext == ".lnk")
                {
                    string filename = ResolveShorcut(s[0]);
                    if (System.IO.Path.GetExtension(filename) == ".xml")
                    {
                        TextboxAutoLoadSetting.Text = s[0];
                    }
                }
            }
        }

        private void TextboxAutoLoadSetting_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ButtonSelectAutoLoadSetting_Click(object sender, EventArgs e)
        {
            // OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "xmlを追加";
            dialog.Filter = "xmlファル|*.xml";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextboxAutoLoadSetting.Text = dialog.FileName;
            }
            dialog.Dispose();
        }
    }
}
