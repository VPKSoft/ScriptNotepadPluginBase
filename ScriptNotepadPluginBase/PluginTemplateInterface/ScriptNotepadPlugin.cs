﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ScriptNotepadPluginBase.PluginTemplateInterface
{
    /// <summary>
    /// A class for common methods to be used with a ScriptNotepad plug-in
    /// </summary>
    public class ScriptNotepadPlugin
    {
        /// <summary>
        /// A list containing messages for localization. Please do fill at least the en-US localization.
        /// </summary>
        List<(string MessageName, string Message, string CultureName)> LocalizationTexts { get; set; } = 
            new List<(string MessageName, string Message, string CultureName)>();

        /// <summary>
        /// Gets or sets the <see cref="MenuStrip"/> which is the main menu of the hosting software (ScriptNotepad).
        /// </summary>
        public MenuStrip ScriptNotepadMainMenu { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScriptNotepadPlugin"/> is initialized <see cref="IScriptNotepadPlugin.Initialize"/>.
        /// </summary>
        public bool Initialized { get; set; } = false;

        /// <summary>
        /// Gets a localized message and gets a string corresponding to that message.
        /// </summary>
        /// <param name="messageName">The name of the message to get.</param>
        /// <param name="defaultMessage">The default value for the message if none were found in the <see cref="LocalizationTexts"/> with the locale of <paramref name="locale"/>.</param>
        /// <param name="locale">A locale expressed as a string.</param>
        /// <returns>A localized message with the given parameters.</returns>
        public string GetMessage(string messageName, string defaultMessage, string locale)
        {
            var value = LocalizationTexts.FirstOrDefault(f => f.CultureName == locale && f.MessageName == messageName);

            if (value.Message == null && locale.Split('-').Length == 2)
            {
                value = LocalizationTexts.FirstOrDefault(f => f.CultureName == locale.Split('-')[0] && f.MessageName == messageName);
            }

            return value.Message != null ? value.Message : defaultMessage;
        }

        /// <summary>
        /// Gets a localized message and gets a string corresponding to that message with given arguments.
        /// </summary>
        /// <param name="messageName">The name of the message to get.</param>
        /// <param name="defaultMessage">The default value for the message if none were found in the <see cref="LocalizationTexts"/> with the locale of <paramref name="locale"/>.</param>
        /// <param name="locale">A locale expressed as a string.</param>
        /// <param name="args">An object array that contains zero or more objects to format the message.</param>
        /// <returns>A localized message with the given parameters.</returns>
        public string GetMessage(string messageName, string defaultMessage, string locale, params object[] args)
        {
            var value = LocalizationTexts.FirstOrDefault(f => f.CultureName == locale && f.MessageName == messageName);

            if (value.Message == null && locale.Split('-').Length == 2)
            {
                value = LocalizationTexts.FirstOrDefault(f => f.CultureName == locale.Split('-')[0] && f.MessageName == messageName);
            }

            string msg = value.Message != null ? value.Message : defaultMessage;
            try
            {
                return string.Format(msg, args);
            }
            catch
            {
                return msg;
            }
        }

        /// <summary>
        /// Fills the <see cref="LocalizationTexts"/> array with a given file contents as a list of strings.
        /// </summary>
        /// <param name="fileContents"></param>
        public void GetLocalizedTexts(string fileContents)
        {
            List<string> fileLines = new List<string>();
            fileLines.AddRange(fileContents.Split(Environment.NewLine.ToArray()));

            string locale = string.Empty;

            for (int i = 0; i < fileLines.Count; i++)
            {
                if (fileLines[i].StartsWith("["))
                {
                    try
                    {
                        locale = fileLines[i].Trim('[', ']');
                        locale = new CultureInfo(locale).Name;
                    }
                    catch
                    {
                        locale = string.Empty;
                    }
                    continue;
                }

                if (locale == string.Empty)
                {
                    continue;
                }

                string[] delimited = fileLines[i].Split('\t');
                if (delimited.Length >= 2)
                {
                    if (LocalizationTexts.Exists(f => f.CultureName == locale && f.MessageName == delimited[0]))
                    {
                        continue;
                    }
                    LocalizationTexts.Add((delimited[0], delimited[1], locale));
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
