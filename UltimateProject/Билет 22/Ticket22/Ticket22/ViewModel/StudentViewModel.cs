using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket22.Model;

namespace Ticket22.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                ApplyFilter();
            }
        }

        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Student> FilteredStudents { get; set; }


        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student("Иван", "Иванов"),
                new Student("Петр", "Петров"),
                new Student("Анна", "Сидорова"),
                new Student("Мария", "Иванова"),
                new Student("Сергей", "Петров")
            };
            FilteredStudents = new ObservableCollection<Student>(Students);

        }
        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                FilteredStudents = new ObservableCollection<Student>(Students);
                return;
            }

            var filter = FilterText.Trim().ToLower();
            FilteredStudents = new ObservableCollection<Student>(Students.Where(s =>
                !string.IsNullOrEmpty(s.FirstName) && s.FirstName.Trim().ToLower().Contains(filter) ||
                !string.IsNullOrEmpty(s.LastName) && s.LastName.Trim().ToLower().Contains(filter)
                 ));

            OnPropertyChanged(nameof(FilteredStudents));
        }

        public void ClearFilter()
        {
            FilterText = "";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
