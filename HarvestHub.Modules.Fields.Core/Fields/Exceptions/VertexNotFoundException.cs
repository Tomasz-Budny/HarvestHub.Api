﻿using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.Exceptions
{
    internal class VertexNotFoundException : HarvestHubException
    {
        public VertexId VertexId { get; }
        public VertexNotFoundException(VertexId vertexId) : base($"Vertex with provided id: {vertexId} was not found for this field!")
        {
            VertexId = vertexId;
        }
    }
}
