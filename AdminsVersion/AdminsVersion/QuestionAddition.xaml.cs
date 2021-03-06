﻿using CodeExecution;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using System.Linq;
using System;
using System.Windows.Input;

namespace AdminsVersion
{
    public partial class QuestionAddition : Window
    {
        private List<Limit> _limits = new List<Limit>();

        public QuestionAddition(List<Topic> topics)
        {
            InitializeComponent();

            foreach (var topic in topics)
                Topics.Items.Add(topic.Title);

            Code.Text = @"public static class Execution
{
	public static int Main(int n)
	{
		var x = 0;
		return x;
	}
}";
        }

        public int GetTopic()
        {
            return Topics.SelectedIndex;
        }

        public string GetText()
        {
            return Text.Text;
        }


        public string GetCode()
        {
            return Code.Text;
        }

        public List<Limit> GetLimits()
        {
            return _limits;
        }


        private bool SuccessfulExecution(out CompilerErrorCollection errors)
        {
            return QuastionCreation.TryCreateParameterQuestion(GetCode(), GetText(), GetLimits(), out var question,
                out errors);
        }


        private static void Return_Errors(CompilerErrorCollection errors)
        {
            var message = "Ошибка компиляции" + Environment.NewLine;
            var compilerErrorList = errors.Cast<CompilerError>();

            foreach (var compilerError in compilerErrorList)
                message += string.Format(Environment.NewLine + "line{0}: {1}",
                    compilerError.Line - CodeCreation.UsingsCount, compilerError.ErrorText);

            MessageBox.Show(message);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Topics.SelectedIndex == -1)
                MessageBox.Show("Не выбрана тема");
            else if (new Regex("#").Matches(Text.Text).Count != Limits.Items.Count)
                MessageBox.Show("Количество ограничений не корректно");
            else if (!SuccessfulExecution(out var errors))
                Return_Errors(errors);
            else DialogResult = true;
        }

        private void AddLimit_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Min.Text, out var min);
            int.TryParse(Max.Text, out var max);

            if (min >= max)
            {
                MessageBox.Show("Некорректный интервал");
                return;
            }

            _limits.Add(new Limit(min, max));

            Limits.Items.Add(Min.Text + "-" + Max.Text);
            Min.Text = "";
            Max.Text = "";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void TextBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox txtBox && txtBox.Text == "Вопрос")
                txtBox.Text = string.Empty;
        }

        private new void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            var regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void Limits_KeyUp(object sender, KeyEventArgs e)
        {
            var index = Limits.SelectedIndex;

            if (index!=-1 && e.Key == Key.Delete)
            {
                Limits.Items.RemoveAt(index);
                _limits.RemoveAt(index);
            }
        }
    }
}
