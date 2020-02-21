﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamPreparatyion___IRunes.ViewModels.Tracks
{
    public class TracksDetailsViewModel
    {
        public string AlbumId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string IFrameSource
        {
            get
            {
                if (this.Link.Contains("youtube"))
                {
                    var regex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)(?<id>[a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
                    var videoId = regex.Match(this.Link).Groups["id"];
                    return $"https://www.youtube.com/embed/{videoId}";
                }
                else
                {
                    return this.Link;
                }
            }
        }
        public string Link { get; set; }
    }
}