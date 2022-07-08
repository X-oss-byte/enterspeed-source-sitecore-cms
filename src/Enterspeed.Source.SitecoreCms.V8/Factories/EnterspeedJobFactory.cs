﻿using System;
using Enterspeed.Source.SitecoreCms.V8.Data.Models;
using Sitecore.Data.Items;

namespace Enterspeed.Source.SitecoreCms.V8.Factories
{
    public class EnterspeedJobFactory : IEnterspeedJobFactory
    {
        public EnterspeedJob GetPublishJob(Item content, string culture, EnterspeedContentState state)
        {
            var now = DateTime.UtcNow;
            return new EnterspeedJob
            {
                EntityId = content.ID.ToString(),
                EntityType = EnterspeedJobEntityType.Content,
                Culture = culture,
                JobType = EnterspeedJobType.Publish,
                JobState = EnterspeedJobState.Pending,
                CreatedAt = now,
                UpdatedAt = now,
                ContentState = state
            };
        }

        public EnterspeedJob GetDeleteJob(Item content, string culture, EnterspeedContentState state)
        {
            var now = DateTime.UtcNow;
            return new EnterspeedJob
            {
                EntityId = content.ID.ToString(),
                EntityType = EnterspeedJobEntityType.Content,
                Culture = culture,
                JobType = EnterspeedJobType.Delete,
                JobState = EnterspeedJobState.Pending,
                CreatedAt = now,
                UpdatedAt = now,
                ContentState = state
            };
        }

        public EnterspeedJob GetFailedJob(EnterspeedJob job, string exception)
        {
            return new EnterspeedJob
            {
                EntityId = job.EntityId,
                EntityType = job.EntityType,
                Culture = job.Culture,
                CreatedAt = job.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
                JobType = job.JobType,
                JobState = EnterspeedJobState.Failed,
                ContentState = job.ContentState,
                Exception = exception
            };
        }
    }
}