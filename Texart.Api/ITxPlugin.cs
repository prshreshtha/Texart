﻿using System.Collections.Generic;

namespace Texart.Api
{
    /// <summary>
    /// A plugin represents a collection of named <see cref="ITxTextBitmapGenerator"/> and <see cref="ITxTextBitmapRenderer"/>.
    /// The plugin abstraction allows sharing these types across assembly boundaries.
    ///
    /// <see cref="ITxPlugin"/> unifies sharing "resources" (like algorithms) in the following contexts:
    ///   * Within Texart code.
    ///   * Within a separately compiled assembly, built against <c>Texart.Api</c>.
    ///   * Within a <c>.tx.csx</c> script file that will be interpreted by the Texart runtime.
    /// </summary>
    public interface ITxPlugin
    {
        /// <summary>
        /// Available names of <see cref="ITxTextBitmapGenerator"/>. Every name listed here must be valid when calling
        /// <see cref="LookupGenerator"/>.
        /// </summary>
        IEnumerable<TxPluginResourceLocator.RelativeLocator> AvailableGenerators { get; }

        /// <summary>
        /// Returns a factory function that constructs an <see cref="ITxTextBitmapGenerator"/> identified by
        /// <paramref name="locator"/>, or a "redirect" locator which represents another lookup
        /// (<see cref="TxPluginResource.Redirect{T}"/> and <see cref="TxPluginResourceLocator"/>).
        /// </summary>
        /// <param name="locator">
        ///     The resource to look up. This identity <i>should</i> appear in <see cref="AvailableGenerators"/>
        ///     but is not required to. If a plugin exports a "default" type, then the type should be available
        ///     as an empty <see cref="TxPluginResourceLocator.ResourcePath"/>.
        /// </param>
        /// <returns>A resource specification for <see cref="ITxTextBitmapGenerator"/></returns>
        /// <seealso cref="TxPluginResource.OfFactory{T}"/>
        /// <seealso cref="TxPluginResource.OfGeneratorFactory{T}"/>
        /// <seealso cref="TxPluginResource.Redirect{T}"/>
        /// <seealso cref="TxPluginResource.RedirectGenerator"/>
        TxPluginResource<ITxTextBitmapGenerator> LookupGenerator(TxPluginResourceLocator locator);

        /// <summary>
        /// Available names of <see cref="ITxTextBitmapRenderer"/>. Every name listed here must be valid when calling
        /// <see cref="LookupRenderer"/>.
        /// </summary>
        IEnumerable<TxPluginResourceLocator.RelativeLocator> AvailableRenderers { get; }

        /// <summary>
        /// Returns a factory function that constructs an <see cref="ITxTextBitmapRenderer"/> identified by
        /// <paramref name="locator"/>, or a "redirect" locator which represents another lookup
        /// (<see cref="TxPluginResource.Redirect{T}"/> and <see cref="TxPluginResourceLocator"/>).
        /// </summary>
        /// <param name="locator">
        ///     The resource to look up. This identity <i>should</i> appear in <see cref="AvailableRenderers"/>
        ///     but is not required to. If a plugin exports a "default" type, then the type should be available
        ///     as an empty <see cref="TxPluginResourceLocator.ResourcePath"/>.
        /// </param>
        /// <returns>A resource specification for <see cref="ITxTextBitmapRenderer"/></returns>
        /// <seealso cref="TxPluginResource.OfFactory{T}"/>
        /// <seealso cref="TxPluginResource.OfRendererFactory{T}"/>
        /// <seealso cref="TxPluginResource.Redirect{T}"/>
        /// <seealso cref="TxPluginResource.RedirectRenderer"/>
        TxPluginResource<ITxTextBitmapRenderer> LookupRenderer(TxPluginResourceLocator locator);
    }
}