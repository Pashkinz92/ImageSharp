// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.Linq;
using SixLabors.ImageSharp.Formats.Webp.Lossy;
using SixLabors.ImageSharp.Tests.TestUtilities;
using Xunit;

namespace SixLabors.ImageSharp.Tests.Formats.WebP
{
    [Trait("Format", "Webp")]
    public class Vp8EncodingTests
    {
        private static void RunInverseTransformTest()
        {
            // arrange
            byte[] reference =
            {
                128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129,
                129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128,
                128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129,
                129, 129, 129, 129, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128,
                129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 129, 128, 128, 128, 128,
                128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 128, 129, 129, 129, 129, 129, 129, 129, 129,
                129, 129, 129, 129, 129, 129, 129, 129
            };
            short[] input = { 1, 216, -48, 0, 96, -24, -48, 24, 0, -24, 24, 0, 0, 0, 0, 0, 38, -240, -72, -24, 0, -24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] dst = new byte[128];
            byte[] expected =
            {
                161, 160, 149, 105, 78, 127, 156, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 160, 160, 133, 85, 81, 129, 155, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 156, 147, 109, 76, 85, 130, 153, 163, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 152, 128, 87, 83, 88, 132, 152, 159, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };
            int[] scratch = new int[16];

            // act
            Vp8Encoding.ITransform(reference, input, dst, true, scratch);

            // assert
            Assert.True(dst.SequenceEqual(expected));
        }

        [Fact]
        public void InverseTransform_Works() => RunInverseTransformTest();

#if SUPPORTS_RUNTIME_INTRINSICS
        [Fact]
        public void InverseTransform_WithHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunInverseTransformTest, HwIntrinsics.AllowAll);

        [Fact]
        public void InverseTransform_WithoutHardwareIntrinsics_Works() => FeatureTestRunner.RunWithHwIntrinsicsFeature(RunInverseTransformTest, HwIntrinsics.DisableHWIntrinsic);
#endif
    }
}
