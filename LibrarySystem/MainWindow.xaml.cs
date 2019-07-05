using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Windows;
using LibrarySystem.Models;
using LibrarySystem.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace LibrarySystem
{
    public partial class MainWindow
    {
        private LibraryContextRepository _libraryContextRepository;

        public MainWindow()
        {
            _libraryContextRepository = new LibraryContextRepository();
            InitializeComponent();
        }

        private void PrintSchoolchildByClass(object sender, RoutedEventArgs e)
        {
            var schoolchildByClass = _libraryContextRepository.GetSchoolchildByClass(int.Parse(NumberOfClass.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = schoolchildByClass.Result;
            Result.Content = null;
            Result.Content = "Результат 1 запроса";
        }

        private void PrintWorkerByWorkPlace(object sender, RoutedEventArgs e)
        {
            var workerByWorkPlace = _libraryContextRepository.GetWorkerByWorkPlace(WorkPlace.Text);
            grid.ItemsSource = null;
            grid.ItemsSource = workerByWorkPlace.Result;
            Result.Content = null;
            Result.Content = "Результат 2 запроса";
        }

        private void PrintTeacherByUniversity(object sender, RoutedEventArgs e)
        {
            var teacherByUniversity = _libraryContextRepository.GetTeacherByUniversity(NameOfUniversity.Text);
            grid.ItemsSource = null;
            grid.ItemsSource = teacherByUniversity.Result;
            Result.Content = null;
            Result.Content = "Результат 3 запроса";
        }

        private void PrintPensionerByNumberOfPensionDocument(object sender, RoutedEventArgs e)
        {
            var pensionerByNumberOfPensionDocument = _libraryContextRepository.GetPensionerByNumberOfPensionDocument(
                int.Parse(NumberOfPensionDocument.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = new List<Pensioner>() {pensionerByNumberOfPensionDocument.Result};
            Result.Content = null;
            Result.Content = "Результат 4 запроса";
        }

        private void PrintStudentByUniversity(object sender, RoutedEventArgs e)
        {
            var studentByUniversity = _libraryContextRepository.GetStudentByUniversity(NameOfUniversityByStudent.Text);
            grid.ItemsSource = null;
            grid.ItemsSource = studentByUniversity.Result;
            Result.Content = null;
            Result.Content = "Результат 5 запроса";
        }

        private void PrintPeopleByReadingProduct(object sender, RoutedEventArgs e)
        {
            var peopleByReadingProduct = _libraryContextRepository.GetPeopleByReadingProduct(NameOfBook.Text);
            grid.ItemsSource = null;
            if (peopleByReadingProduct != null)
            {
                grid.ItemsSource = peopleByReadingProduct.Result;
            }

            Result.Content = null;
            Result.Content = "Результат 6 запроса";
        }

        private void PrintPeopleByReadingProductOnTime(object sender, RoutedEventArgs e)
        {
            DateTime startDay;
            DateTime finishDay;
            var startDayIsParsed = DateTime.TryParse(datePicker1.SelectedDate.ToString(), out startDay);
            var finishDayIsParsed = DateTime.TryParse(datePicker2.SelectedDate.ToString(), out finishDay);

            if (startDayIsParsed && finishDayIsParsed)
            {
                var peopleByReadingProductOnTime = _libraryContextRepository.GetPeopleByReadingProductOnTime(
                    startDay,
                    finishDay);
                grid.ItemsSource = null;
                grid.ItemsSource = peopleByReadingProductOnTime.Result;
                Result.Content = null;
                Result.Content = "Результат 7 запроса";
            }
        }

        private void PrintMostPopularProduct(object sender, RoutedEventArgs e)
        {
            var popularProduct = _libraryContextRepository.GetMostPopularProduct();
            grid.ItemsSource = null;
            grid.ItemsSource = new List<Product> {popularProduct.Result};
            Result.Content = null;
            Result.Content = "Результат 8 запроса";
        }

        private void PrintWorkerLibraryByLibrary(object sender, RoutedEventArgs e)
        {
            var workerLibraryByLibrary = _libraryContextRepository.GetWorkerLibraryByLibrary(int.Parse(IdLibrary.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = workerLibraryByLibrary.Result;
            Result.Content = null;
            Result.Content = "Результат 9 запроса";
        }

        private void PrintOverdueReader(object sender, RoutedEventArgs e)
        {
            var overdueReader = _libraryContextRepository.GetOverdueReader();
            grid.ItemsSource = null;
            grid.ItemsSource = overdueReader.Result;
            Result.Content = null;
            Result.Content = "Результат 10 запроса";
        }

        private void PrintProductByLocation(object sender, RoutedEventArgs routedEventArgs)
        {
            var productByLocation = _libraryContextRepository.GetProductByLocation(int.Parse(NumberOfShelving.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = productByLocation.Result;
            Result.Content = null;
            Result.Content = "Результат 11 запроса";
        }

        private void PrintPeopleServicedByLibraryWorker(object sender, RoutedEventArgs e)
        {
            var servicedByLibraryWorker =
                _libraryContextRepository.GetPeopleServicedByLibraryWorker(int.Parse(LibraryWorkerId.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = servicedByLibraryWorker.Result;
            Result.Content = null;
            Result.Content = "Результат 12 запроса";
        }

        private void PrintProductByAuthor(object sender, RoutedEventArgs e)
        {
            var product = _libraryContextRepository.GetProductByAuthor(int.Parse(AuthorId.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = product.Result;
            Result.Content = null;
            Result.Content = "Результат 13 запроса";
        }

        private void PrintCountPeopleServicedByLibraryWorker(object sender, RoutedEventArgs e)
        {
            DateTime startDay;
            DateTime finishDay;
            var startDayIsParsed = DateTime.TryParse(datePicker3.SelectedDate.ToString(), out startDay);
            var finishDayIsParsed = DateTime.TryParse(datePicker4.SelectedDate.ToString(), out finishDay);

            if (startDayIsParsed && finishDayIsParsed)
            {
                var countPeople = _libraryContextRepository.GetPeopleByReadingProductOnTime(
                    startDay,
                    finishDay);
                grid.ItemsSource = null;
                grid.ItemsSource = countPeople.Result;
                Result.Content = null;
                Result.Content = "Результат 14 запроса";
            }
        }

        private void ShowTickets(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddReader();
            newWindow.Show();
        }
    }
}