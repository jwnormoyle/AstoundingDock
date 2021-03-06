﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace AstoundingApplications.AstoundingDock.Models
{
    class TabModel : IEquatable<TabModel>
    {
        string _title;
        string _oldTitle;

        public TabModel() : this(null, true, 1, new List<ApplicationModel>())
        {
        }

        public TabModel(string title, bool isExpanded, int tabOrder) : 
            this(title, isExpanded, tabOrder, new List<ApplicationModel>()) 
        { 
        }

        public TabModel(string title, bool isExpanded, int tabOrder, List<ApplicationModel> applications)
        {
            _title = title;
            IsExpanded = isExpanded;
            Applications = applications;
            TabOrder = tabOrder;
        }        

        public string Title
        {
            get { return _title; }
            set
            {
                _oldTitle = _title;
                _title = value;               
            }
        }
        public string OldTitle { get { return _oldTitle ?? _title; } }
        public bool IsExpanded { get; set; }
        public int TabOrder { get; set; }
        public List<ApplicationModel> Applications { get; private set; }

        public TabModel Copy()
        {
            TabModel section = new TabModel(Title, IsExpanded, TabOrder, Applications.ToList());
            return section;
        }

        public override string ToString()
        {
            return String.Format("Title: {0}, Applications: {1}", Title, Applications.Count);
        }

        public bool Equals(TabModel other)
        {
            if (other == null)
                return false;

            return String.Equals(Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
