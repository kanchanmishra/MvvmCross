﻿// MvxRgbIntValueConverterTest.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
//
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.Globalization;
using MvvmCross.Test;
using Xunit;

namespace MvvmCross.Plugins.Color.Test
{
    [Collection("Color")]
    public class MvxRgbIntValueConverterTest : MvxColorValueConverterTest
    {
        public MvxRgbIntValueConverterTest(MvxTestFixture fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData(0xffffff, 0xFFffffff)]
        [InlineData(0x000000, 0xFF000000)]
        [InlineData(0x123456, 0xFF123456)]
        [InlineData(0xA23BCD, 0xFFA23BCD)]
        [InlineData(0x02A040, 0xFF02A040)]
        [InlineData(0x7B02A040, 0xFF02A040)]
        public void ConvertRGBIntToColor(int rgb, uint argb)
        {
            var converter = new MvxRGBIntColorValueConverter();
            var actual = converter.Convert(rgb, typeof(object), null, CultureInfo.CurrentUICulture);
            var wrapped = actual as WrappedColor;
            Assert.NotNull(wrapped);
            Assert.Equal(argb, (uint)wrapped.Color.ARGB);
        }
    }
}