﻿using System;
using CoreGraphics;
using CoreLocation;
using Foundation;
using MapKit;

namespace TK.CustomMap.iOSUnified
{
    /// <summary>
    /// Custom map annotation
    /// </summary>
    [Preserve(AllMembers = true)]
    internal class TKCustomMapAnnotation : MKAnnotation
    {
        private CLLocationCoordinate2D _coordinate;
        private readonly TKCustomMapPin _formsPin;

        ///<inheritdoc/>
        public override string Title
        {
            get
            {
                return this._formsPin.Title;
            }
        }
        ///<inheritdoc/>
        public override string Subtitle
        {
            get
            {
                return this._formsPin.Subtitle;
            }
        }
        ///<inheritdoc/>
        public override CLLocationCoordinate2D Coordinate
        {
            get { return _coordinate; }
        }
        /// <summary>
        /// Gets the forms pin
        /// </summary>
        public TKCustomMapPin CustomPin
        {
            get { return this._formsPin; }
        }
        ///<inheritdoc/>
        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            this.WillChangeValue("coordinate");
            _coordinate = value;
            this.DidChangeValue("coordinate");
        }
        /// <summary>
        /// Xamarin.iOS does (still) not export <value>_original_setCoordinate</value>
        /// </summary>
        /// <param name="value">The coordinate</param>
        [Export("_original_setCoordinate:")]
        public void SetCoordinateOriginal(CLLocationCoordinate2D value)
        {
            this._formsPin.Position = value.ToPosition();
            this.SetCoordinate(value);
        }
        /// <summary>
        /// Creates a new instance of <see cref="TKCustomMapAnnotation"/>
        /// </summary>
        /// <param name="pin">The forms pin</param>
        public TKCustomMapAnnotation(TKCustomMapPin pin)
        {
            this._formsPin = pin;
            this._coordinate = pin.Position.ToLocationCoordinate();
        }
    }
}
