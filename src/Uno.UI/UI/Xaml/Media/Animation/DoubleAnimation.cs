﻿using Uno.Extensions;
using System;
using System.Collections.Generic;
using Uno.Disposables;
using System.Text;
using System.Linq;
using Uno.Diagnostics.Eventing;
using Windows.UI.Core;
using Uno.Logging;

namespace Windows.UI.Xaml.Media.Animation
{
	public partial class DoubleAnimation : Timeline, ITimeline, IAnimation<float>
	{
		private readonly AnimationImplementation<float> _animationImplementation;

		public DoubleAnimation()
		{
			_animationImplementation = new AnimationImplementation<float>(this);
		}

		public double? By
		{
			get => (double?)GetValue(ByProperty);
			set => SetValue(ByProperty, value);
		}

		public static readonly DependencyProperty ByProperty =
			DependencyProperty.Register("By", typeof(double?), typeof(DoubleAnimation), new PropertyMetadata(null));

		public double? From
		{
			get => (double?)GetValue(FromProperty);
			set => SetValue(FromProperty, value);
		}

		public static readonly DependencyProperty FromProperty =
			DependencyProperty.Register("From", typeof(double?), typeof(DoubleAnimation), new PropertyMetadata(null));

		public double? To
		{
			get => (double?)GetValue(ToProperty);
			set => SetValue(ToProperty, value);
		}

		public static readonly DependencyProperty ToProperty =
			DependencyProperty.Register("To", typeof(double?), typeof(DoubleAnimation), new PropertyMetadata(null));

		public bool EnableDependentAnimation
		{
			get => (bool)GetValue(EnableDependentAnimationProperty);
			set => SetValue(EnableDependentAnimationProperty, value);
		}

		bool IAnimation<float>.EnableDependentAnimation => EnableDependentAnimation;

		public static readonly DependencyProperty EnableDependentAnimationProperty =
			DependencyProperty.Register("EnableDependentAnimation", typeof(bool), typeof(DoubleAnimation), new PropertyMetadata(false));

		public IEasingFunction EasingFunction
		{
			get => (IEasingFunction)GetValue(EasingFunctionProperty);
			set => SetValue(EasingFunctionProperty, value);
		}

		IEasingFunction IAnimation<float>.EasingFunction => EasingFunction;

		float? IAnimation<float>.To => (float?)To;

		float? IAnimation<float>.From => (float?)From;

		float? IAnimation<float>.By => (float?)By;

		public static readonly DependencyProperty EasingFunctionProperty =
			DependencyProperty.Register("EasingFunction", typeof(IEasingFunction), typeof(DoubleAnimation), new PropertyMetadata(null));

		void ITimeline.Begin() => _animationImplementation.Begin();

		void ITimeline.Stop() => _animationImplementation.Stop();

		void ITimeline.Resume() => _animationImplementation.Resume();

		void ITimeline.Pause() => _animationImplementation.Pause();

		void ITimeline.Seek(TimeSpan offset) => _animationImplementation.Seek(offset);

		void ITimeline.SeekAlignedToLastTick(TimeSpan offset) => _animationImplementation.SeekAlignedToLastTick(offset);

		void ITimeline.SkipToFill() => _animationImplementation.SkipToFill();

		void ITimeline.Deactivate() => _animationImplementation.Deactivate();

		/// <summary>
		/// Dispose the Double animation.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_animationImplementation.Dispose();
			}

			base.Dispose(disposing);
		}

		float IAnimation<float>.Subtract(float minuend, float subtrahend) => minuend - subtrahend;

		float IAnimation<float>.Add(float first, float second) => first + second;

		float IAnimation<float>.Convert(object value) => Convert.ToSingle(value);

		float IAnimation<float>.Multiply(float multiplier, float t) => multiplier * t;
	}
}

