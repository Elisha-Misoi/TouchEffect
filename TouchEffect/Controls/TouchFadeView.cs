﻿using System;
using TouchEffect.Enums;
using Xamarin.Forms;

namespace TouchEffect.Controls
{
	public class TouchFadeView : TouchView
	{
		public static readonly BindableProperty RegularOpacityProperty = BindableProperty.Create(
			nameof(RegularOpacity),
			typeof(double),
			typeof(TouchView),
			1.0,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				(bindable as TouchFadeView)?.ForceStateChanged();
			});

		public static readonly BindableProperty PressedOpacityProperty = BindableProperty.Create(
			nameof(PressedOpacity),
			typeof(double),
			typeof(TouchView),
			0.8,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				(bindable as TouchFadeView)?.ForceStateChanged();
			});

		public static readonly BindableProperty FadeTimeProperty = BindableProperty.Create(
    		nameof(FadeTime),
    		typeof(int),
    		typeof(TouchView),
    		200);

		public static readonly BindableProperty FadeEasingProperty = BindableProperty.Create(
			nameof(FadeEasing),
			typeof(Easing),
			typeof(TouchView),
			null);

		public double RegularOpacity
		{
			get => (double)GetValue(RegularOpacityProperty);
			set => SetValue(RegularOpacityProperty, value);
		}

		public double PressedOpacity
		{
			get => (double)GetValue(PressedOpacityProperty);
			set => SetValue(PressedOpacityProperty, value);
		}

		public int FadeTime
		{
			get => (int)GetValue(FadeTimeProperty);
			set => SetValue(FadeTimeProperty, value);
		}

		public Easing FadeEasing
        {
			get => GetValue(FadeEasingProperty) as Easing;
			set => SetValue(FadeEasingProperty, value);
        }

		protected override void OnStateChanged(TouchView sender, EventArgs.TouchStateChangedEventArgs args)
        {
			var opacity = args.State == TouchState.Regular
                              ? RegularOpacity
                              : PressedOpacity;

            this.FadeTo(opacity, (uint)Math.Abs(FadeTime), FadeEasing);
        }
	}
}
