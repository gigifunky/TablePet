﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TablePet.Services.Controllers;
using TablePet.Services.Models;

namespace TablePet.Win.Calendar
{
    /// <summary>
    /// Calendar.xaml 的交互逻辑
    /// </summary>
    public partial class CalendarWindow : Window
    {
        private DateTime currentMonth;
        private CalendarService calendarService;
        private DateTime selectedDate;
        private Timer notificationTimer;
        
        public CalendarWindow()
        {
            InitializeComponent();
        }
        
        public CalendarWindow(CalendarService calendarService)
        {
            InitializeComponent();
            this.calendarService = calendarService;
            currentMonth = DateTime.Today;
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            MonthYearLabel.Text = calendarService.GetMonthYearLabel(currentMonth); 
            CalendarGrid.Children.Clear(); 

            int startDay = calendarService.GetStartDayOfMonth(currentMonth); 
            int daysInMonth = calendarService.GetDaysInMonth(currentMonth);
            DateTime today = DateTime.Today; 

            // 添加空白空间以填充该月第一天之前的天数
            for (int i = 0; i < startDay; i++)
            {
                CalendarGrid.Children.Add(new TextBlock()); // 添加空白文本块
            }

            // 为该月的每一天添加按钮
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(currentMonth.Year, currentMonth.Month, day);
                Button dayButton = new Button
                {
                    Content = day.ToString(),
                    Tag = date, 
                    Background = date == today ? Brushes.LightBlue : Brushes.White, 
                    BorderBrush = (date == selectedDate) ? Brushes.LightSlateGray : Brushes.Gray, 
                    BorderThickness = (date == selectedDate) ? new Thickness(2) : new Thickness(1), 
                    Margin = new Thickness(2), 
                    Padding = new Thickness(5), 
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center 
                };
                
                dayButton.Click += (sender, e) => 
                {
                    selectedDate = date; 
                    UpdateCalendar(); 
                    ShowEventsForDate(date); 
                };

                CalendarGrid.Children.Add(dayButton); 
            }
            
            ShowEventsForDate(today);
        }


        private void ShowEventsForDate(DateTime date)
        {
            EventListBox.Items.Clear();
            var events = calendarService.GetEventsForDate(date);
            foreach (var eventDescription in events)
            {
                EventListBox.Items.Add(eventDescription);
            }
        }


        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = DateTime.Today;
            var dialog = new AddEventDialog(selectedDate);

            if (dialog.ShowDialog() == true)
            {
                var newEvent = new CalendarEvent
                {
                    startTime = dialog.EventStartTime,  // 用户选择的时间
                    description = dialog.EventTitle      // 用户输入的事件描述
                };

                // 调用 CalendarService 中的方法保存事件到数据库
                calendarService.AddEvent(newEvent);
                ShowEventsForDate(selectedDate);
            }
        }

        private void PrevMonth_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            UpdateCalendar();
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            UpdateCalendar();
        }
    }
}
