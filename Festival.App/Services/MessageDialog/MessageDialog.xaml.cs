﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Festival.App.Services.MessageDialog
{
    public partial class MessageDialog : Window
    {
        private MessageDialogResult _result;

        public MessageDialog(string title, string text, MessageDialogResult defaultResult,
            MessageDialogButtonConfiguration buttonConfiguration)
        {
            InitializeComponent();
            Title = title;
            textBlock.Text = text;
            _result = defaultResult;
            InitializeButtons(buttonConfiguration);
        }

        private void InitializeButtons(MessageDialogButtonConfiguration buttonConfiguration)
        {
            var buttons = GetButtonsFromConfiguration(buttonConfiguration);

            foreach (var button in buttons)
            {
                var btn = new Button { Content = button, Tag = button };
                ButtonsPanel.Children.Add(btn);
                btn.Click += ButtonClick;
            }
        }

        private static IEnumerable<MessageDialogResult> GetButtonsFromConfiguration(
            MessageDialogButtonConfiguration buttonConfiguration) =>
            buttonConfiguration switch
            {
                MessageDialogButtonConfiguration.Ok => new[] { MessageDialogResult.Ok },
                MessageDialogButtonConfiguration.OkCancel => new[] { MessageDialogResult.Ok, MessageDialogResult.Cancel },
                MessageDialogButtonConfiguration.YesNoCancel => new[] { MessageDialogResult.Yes, MessageDialogResult.No, MessageDialogResult.Cancel },
                MessageDialogButtonConfiguration.YesNo => new[] { MessageDialogResult.Yes, MessageDialogResult.No },
                _ => new[] { MessageDialogResult.Ok }
            };

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is Button button)) return;

            _result = (MessageDialogResult)button.Tag;
            Close();
        }

        public new MessageDialogResult ShowDialog()
        {
            base.ShowDialog();
            return _result;
        }
    }
}