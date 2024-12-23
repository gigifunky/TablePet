﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TablePet.Services;
using TablePet.Services.Models;
using TablePet.Services.Controllers;

namespace TablePet.Win.Notes
{
    /// <summary>
    /// Note.xaml 的交互逻辑
    /// </summary>
    public partial class EditNote : Window
    {
        private NoteService noteService;
        private NoteContext db;
        private Note note_org = null;
        public EditNote()
        {
            InitializeComponent();
        }

        public EditNote(NoteService sv)
        {
            InitializeComponent();
            noteService = sv;
        }

        public EditNote(NoteService sv, Note note)
        {
            InitializeComponent();
            noteService = sv;
            note_org = note;
            tb_noteTitle.Text = note.NoteTitle;
            tb_noteContent.Text = note.NoteContent;
        }


        // 保存按钮
        private void bt_noteSave_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note();
            note.NoteTitle = tb_noteTitle.Text;
            note.NoteContent = tb_noteContent.Text;
            noteService.UpdateNote(note, note_org);
            this.Close();
        }

        // 新建按钮
        private void bt_noteNew_Click(object sender, RoutedEventArgs e)
        {
            EditNote note = new EditNote(noteService);
            note.Show();
        }


        // 关闭按钮
        private void bt_noteClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
