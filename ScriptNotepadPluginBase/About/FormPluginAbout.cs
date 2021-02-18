using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace ScriptNotepadPluginBase.About
{
    /// <summary>
    /// A general about dialog for a plug-in.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FormPluginAbout : Form
    {
        /// <summary>
        /// A field for the plug-in name.
        /// </summary>
        private string pluginName;

        /// <summary>
        /// A field for the assembly of which information to display in the about dialog.
        /// </summary>
        private Assembly aboutAssembly = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormPluginAbout"/> class.
        /// </summary>
        /// <param name="parent">The parent form for the dialog.</param>
        /// <param name="aboutAssembly">The assembly of which information to display within the dialog.</param>
        /// <param name="license">The name of the license for the plug-in.</param>
        /// <param name="licenseUrl">The license URL for the plug-in.</param>
        /// <param name="locale">The locale to be used with the dialog.</param>
        /// <param name="icon">The icon to show on the dialog.</param>
        /// <param name="pluginName">The name of the plug-in.</param>
        /// <param name="logo">The logo for the plug-in and/or company.</param>
        public FormPluginAbout(Form parent, Assembly 
            aboutAssembly, string license, string licenseUrl, 
            string locale, Icon icon, string pluginName,
            Image logo)
        {
            InitializeComponent();
            this.pluginName = pluginName;
            this.aboutAssembly = aboutAssembly;
            MainInit(locale);
            Owner = parent;
            Icon = icon;
            pbLogo.Image = logo;
            sllLinkLicense.Text = license;
            sllLinkLicense.LinkUrl = licenseUrl;
            ShowDialog();
        }

        /// <summary>
        /// Localizes the dialog and sets the assembly information visible.
        /// </summary>
        /// <param name="locale">The locale to be used for the localization of the dialog.</param>
        private void MainInit(string locale)
        {
            try // about dialog shouldn't crash the application
            {
                // for some reason this uses a different notation for locales..
                locale = locale.Replace("-", "_");

                ResourceSet rs = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, false, false);

                string langStr = null;
                foreach (DictionaryEntry entry in rs)
                {
                    if (entry.Key.ToString() == "texts_" + locale)
                    {
                        langStr = entry.Value as string;
                    }
                }

                if (langStr == null)
                {
                    foreach (DictionaryEntry entry in rs)
                    {
                        if (entry.Key.ToString() == "texts_en_US")
                        {
                            langStr = entry.Value as string;
                        }
                    }
                }

                if (langStr != null)
                {
                    List<KeyValuePair<string, string>> langPairs = new List<KeyValuePair<string, string>>();

                    List<string> langStrings = new List<string>();

                    try
                    {
                        langStrings = new List<string>(langStr.Split(Environment.NewLine.ToCharArray()));
                    }
                    catch
                    {

                    }

                    foreach (string str in langStrings)
                    {
                        try
                        {
                            langPairs.Add(new KeyValuePair<string, string>(str.Split('=')[0], str.Split('=')[1]));
                        }
                        catch
                        {

                        }
                    }

                    foreach (KeyValuePair<string, string> langPair in langPairs)
                    {
                        if (langPair.Key == "OK")
                        {
                            btOK.Text = langPair.Value;
                        }
                        else if (langPair.Key == "Text")
                        {
                            try
                            {
                                Text = string.Format(langPair.Value, pluginName);
                            }
                            catch
                            {
                                Text = langPair.Value; // no title in about box title..
                            }
                        }
                        else if (langPair.Key == "Description")
                        {
                            lbBoxDescriptionText.Text = langPair.Value;
                        }
                        else if (langPair.Key == "CompanyName")
                        {
                            lbCompanyNameText.Text = langPair.Value;
                        }
                        else if (langPair.Key == "Copyright")
                        {
                            lbCopyrightText.Text = langPair.Value;
                        }
                        else if (langPair.Key == "ProductName")
                        {
                            lbProductNameText.Text = langPair.Value;
                        }
                        else if (langPair.Key == "Version")
                        {
                            lbVersionText.Text = langPair.Value;
                        }
                        else if (langPair.Key == "License")
                        {
                            lbLicenseText.Text = langPair.Value;
                        }
                    }
                }
            }
            catch
            {
                // do nothing..
            }


            lbProductName.Text = AssemblyProduct;
            lbVersion.Text = AssemblyVersion;
            lbCopyright.Text = AssemblyCopyright;
            lbCompanyName.Text = AssemblyCompany;
            tbBoxDescription.Text = AssemblyDescription;
            tbBoxDescription.HideSelection = true;
            tbBoxDescription.SelectionLength = 0;
            btOK.Focus();
        }

        #region Assembly Attribute Accessors        
        /// <summary>
        /// Gets the assembly title.
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = aboutAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(aboutAssembly.CodeBase);
            }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return aboutAssembly.GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gets the assembly description.
        /// </summary>
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = aboutAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the assembly product.
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = aboutAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the assembly copyright.
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = aboutAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Gets the assembly company.
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = aboutAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
