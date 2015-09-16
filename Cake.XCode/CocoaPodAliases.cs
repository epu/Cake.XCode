﻿using Cake.Core.IO;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.CocoaPods
{
    /// <summary>
    /// Cocoapods aliases.
    /// </summary>
    [CakeAliasCategory("CocoaPods")]
    public static class CocoaPodAliases
    {
        /// <summary>
        /// Runs pod install for the given project directory
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectDirectory">The project directory.</param>
        public static void CocoaPodInstall (this ICakeContext context, DirectoryPath projectDirectory)
        {
            CocoaPodInstall (context, projectDirectory, null);
        }

        /// <summary>
        /// Runs pod install for the given project directory
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectDirectory">The project directory.</param>
        /// <param name="settings">The settings.</param>
        public static void CocoaPodInstall (this ICakeContext context, DirectoryPath projectDirectory, CocoaPodInstallSettings settings)
        {
            var r = new CocoaPodRunner (context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            r.Install (projectDirectory, settings);
        }

        /// <summary>
        /// Runs pod update for the given project directory, updating all pods
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectDirectory">The project directory.</param>
        public static void CocoaPodUpdate (this ICakeContext context, DirectoryPath projectDirectory)
        {
            CocoaPodUpdate (context, projectDirectory, null, new CocoaPodUpdateSettings ());
        }

        /// <summary>
        /// Runs pod update for the given project directory, updating all pods
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectDirectory">The project directory.</param>
        /// <param name="settings">The settings.</param>
        public static void CocoaPodUpdate (this ICakeContext context, DirectoryPath projectDirectory, CocoaPodUpdateSettings settings)
        {
            CocoaPodUpdate (context, projectDirectory, null, settings);
        }

        /// <summary>
        /// Runs pod update for the given project directory, updating only the specified pods
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectDirectory">The project directory.</param>
        /// <param name="podNames">The specific pod names to update.</param>
        /// <param name="settings">The settings.</param>
        public static void CocoaPodUpdate (this ICakeContext context, DirectoryPath projectDirectory, string[] podNames, CocoaPodUpdateSettings settings)
        {
            var r = new CocoaPodRunner (context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            r.Update (projectDirectory, podNames, settings);
        }
    }
}