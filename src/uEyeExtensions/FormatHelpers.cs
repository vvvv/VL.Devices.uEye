using System;
using VL.Lib.Basics.Imaging;
using uEye.Defines;

namespace VL.Devices.uEye
{
    /// <summary>
    /// some helper functions to convert <see cref="VL.Lib.Basics.Imaging.PixelFormat"/> and uEye.Defines.ColorMode
    /// </summary>
    public class FormatHelpers
    {
        /// <summary>
        /// finds appropriate uEye.Defines.ColorMode for given <see cref="VL.Lib.Basics.Imaging.PixelFormat"/>
        /// </summary>
        /// <param name="pixelformat"></param>
        /// <returns></returns>
        public static ColorMode MapPixelFormat(PixelFormat pixelformat)
        {
            switch (pixelformat)
            {
                case PixelFormat.R8:
                    return ColorMode.Mono8;

                case PixelFormat.R16:
                    return ColorMode.Mono16;

                case PixelFormat.R8G8B8:
                    return ColorMode.RGB8Packed;

                case PixelFormat.R8G8B8A8:
                case PixelFormat.R8G8B8X8:
                    return ColorMode.RGBA8Packed;

                case PixelFormat.B8G8R8:
                    return ColorMode.BGR8Packed;

                case PixelFormat.B8G8R8A8:
                case PixelFormat.B8G8R8X8:
                    return ColorMode.BGRA8Packed;


                default:
                    return ColorMode.BGRA8Packed;
            }
        }

        /// <summary>
        /// an enum that defines a subset of uEye.Defines.ColorMode. Only those enums can be converted to an <see cref="VL.Lib.Basics.Imaging.IntPtrImage"/> atm.
        /// </summary>
        public enum AllowedColorMode
        {
            /// <summary>8 Bit Mono </summary>
            Mono8 = ColorMode.Mono8,
            /// <summary>16 Bit Mono </summary>
            Mono16 = ColorMode.Mono16,
            /// <summary>8 Bit RGB </summary>
            RGB8 = ColorMode.RGB8Packed,
            /// <summary>8 Bit RGBA </summary>
            RGBA8 = ColorMode.RGBA8Packed,
            /// <summary>8 Bit RGBA but packed</summary>
            RGBA8Packed = ColorMode.RGBA8Packed,
            /// <summary>8 Bit BGR </summary>
            BGR8 = ColorMode.BGR8Packed,
            /// <summary>8 Bit BGRA </summary>
            BGRA8 = ColorMode.BGRA8Packed
        }

        /// <summary>
        /// just a convenience node doing the cast from <see cref="AllowedColorMode"/> to uEye.Defines.ColorMode
        /// </summary>
        /// <param name="allowedColorMode"></param>
        /// <returns></returns>
        public static ColorMode FromAllowedColorMode(AllowedColorMode allowedColorMode)
        {
            return (ColorMode)allowedColorMode;
        }

        /// <summary>
        /// finds appropriate <see cref="VL.Lib.Basics.Imaging.PixelFormat"/> for given <see cref="AllowedColorMode"/>
        /// </summary>
        /// <param name="allowedcolormode"></param>
        /// <returns></returns>
        public static PixelFormat MapAllowedColorMode(AllowedColorMode allowedcolormode)
        {
            switch (allowedcolormode)
            {
                case AllowedColorMode.Mono8:
                    return PixelFormat.R8;

                case AllowedColorMode.Mono16:
                    return PixelFormat.R16;

                case AllowedColorMode.RGB8:
                    return PixelFormat.R8G8B8;

                case AllowedColorMode.RGBA8:
                    return PixelFormat.R8G8B8A8;

                case AllowedColorMode.BGR8:
                    return PixelFormat.B8G8R8;

                case AllowedColorMode.BGRA8:
                    return PixelFormat.B8G8R8A8;

                default:
                    return PixelFormat.B8G8R8A8;
            }
        }

        /// <summary>
        /// finds appropriate <see cref="VL.Lib.Basics.Imaging.PixelFormat"/> for given uEye.Defines.ColorMode
        /// </summary>
        /// <param name="colormode"></param>
        /// <returns></returns>
        public static PixelFormat MapColorMode(ColorMode colormode)
        {
            switch (colormode)
            {
                case ColorMode.Mono8:
                    return PixelFormat.R8;

                case ColorMode.Mono16:
                    return PixelFormat.R16;

                case ColorMode.RGB8Packed:
                case ColorMode.RGB8Planar:
                    return PixelFormat.R8G8B8;

                case ColorMode.RGBA8Packed:
                    return PixelFormat.R8G8B8A8;

                case ColorMode.BGR8Packed:
                    return PixelFormat.B8G8R8;

                case ColorMode.BGRA8Packed:
                    return PixelFormat.B8G8R8A8;


                default:
                    return PixelFormat.B8G8R8A8;
            }
        }

    }
}
