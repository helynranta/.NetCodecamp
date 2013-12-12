﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Microsoft.Phone.Data.Linq;
using Microsoft.Phone.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PaavoApp
{
    [Table]
    public class AalefDataItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property and database column.
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    NotifyPropertyChanging("ID");
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _day;

        [Column]
        public string Day
        {
            get
            {
                return _day;
            }
            set
            {
                if (_day != value)
                {
                    NotifyPropertyChanging("Day");
                    _day = value;
                    NotifyPropertyChanged("Day");
                }
            }
        }

        private string _coursetype;

        [Column]
        public string CourseType
        {
            get
            {
                return _coursetype;
            }
            set
            {
                if (_coursetype != value)
                {
                    NotifyPropertyChanging("CourseType");
                    _coursetype = value;
                    NotifyPropertyChanged("CourseType");
                }
            }
        }

        private string _name;

        [Column]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    NotifyPropertyChanging("Name");
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _description;

        [Column]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    NotifyPropertyChanging("Description");
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private string _allergies;

        [Column]
        public string Allergies
        {
            get
            {
                return _allergies;
            }
            set
            {
                if (_allergies != value)
                {
                    NotifyPropertyChanging("Allergies");
                    _allergies = value;
                    NotifyPropertyChanged("Allergies");
                }
            }
        }

        // Define completion value: private field, public property and database column.
        private string _price;

        [Column]
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    NotifyPropertyChanging("Allergies");
                    _price = value;
                    NotifyPropertyChanged("Allergies");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the data context that a data context property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}