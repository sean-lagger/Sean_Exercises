﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public abstract class Element
    {
        private static int highest_id = 0;

        private int _x;
        private int _y;

        public Element()
        {
            ID = highest_id++;
            ElementType = "element";
            X = 1;
            Y = 1;
            Length = 1;
            isEnabled = true;
        }

        public Element(string type): this()
        {
            ElementType = type;
        }

        public Element(int px, int py) : this()
        {
            X = px;
            Y = py;
        }


        public Element(string type, int px, int py): this(type)
        {
            X = px;
            Y = py;
        } 

        public int ID { get; set; }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                onUpdate();
            }
        }

        public int Y {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                onUpdate();
            }
        }

        #region Properties
        public bool isEnabled;
        public CForm ParentForm { get; set; }
        public int Length { get; set; } //offset of two if borders are enabled **UNIMPLEMENTED
        public string ElementType { get; protected set; }
        public ConsoleColor BackgroundColor { get; set; }
        #endregion


        public virtual void onUpdate()
        {
            if(ParentForm != null)
            {
                ParentForm.UpdateRow(Y);
            }
           
        }

        public virtual void Display()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
        }


    }
}