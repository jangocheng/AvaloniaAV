﻿using Avalonia;
using Avalonia.Controls;
using AvaloniaAV.Framebuffer;
using AvaloniaAV.Framebuffer.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Avalonia
{
    public static partial class AppBuilderExtensions
    {
        public static TAppBuilder UseAvaloniaAV<TAppBuilder>(this TAppBuilder builder)
            where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        {
            new AvaloniaAV.DefaultModule();
            return builder;
        }
    }
}

namespace AvaloniaAV
{
    class DefaultModule
    {
        public DefaultModule()
        {
            AvaloniaLocator.CurrentMutable
                .Bind<IPlatformPlayerProvider>()
                .ToConstant(new PlatformCameraProviderAdapter(AvaloniaLocator.Current.GetService<IPlatformFramebufferPlayerProvider>()));
        }
    }
}