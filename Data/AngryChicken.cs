﻿/*

* Author: Blake Hachen

* Class name: Angry Chicken

* Purpose: Gives information regarding the Angry Chicken entree.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing the Angry Chicken entree
    /// </summary>
    public class AngryChicken : Entree, INotifyPropertyChanged
    {

        private bool bread = true;
        /// <summary>
        /// If the sandwich has bread
        /// </summary>
        public bool Bread
        {
            get { return bread; }
            set
            {
                bread = value;
                NotifyIfPropertyChanges("Bread");
            }
        }

        private bool pickle = true;
        /// <summary>
        /// If the sandwich has pickles
        /// </summary>
        public bool Pickle
        {
            get { return pickle; }
            set 
            { 
                pickle = value;
                NotifyIfPropertyChanges("Pickle");
            }
        }
        
        /// <summary>
        /// The price of the sandwich
        /// </summary>
        public override double Price
        {
            get
            {
                return 5.99;
            }
        }

        /// <summary>
        /// The calories of the sandwich
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 190;
            }
        }

        /// <summary>
        /// Special Instructions for the preparation of the sandwich
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!bread) instructions.Add("hold bread");
                if (!pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }

        /// <summary>
        /// Readable string representing entree Angry Chicken
        /// </summary>
        public override string ToString()
        {
            return "Angry Chicken";
        }




    }
}
