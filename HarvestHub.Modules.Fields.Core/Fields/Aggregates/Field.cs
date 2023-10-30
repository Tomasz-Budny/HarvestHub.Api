using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Aggregates
{
    public class Field : AggregateRoot<FieldId>
    {
        public OwnerId OwnerId { get; set; }
        public Name Name { get; set; }
        public Vertex Center { get; set; }
        public Area Area { get; set; }
        public Class Class { get; set; }
        public Address Address { get; set; }

        protected LinkedList<Vertex> _vertices = new();

        public Field(FieldId id) : base(id)
        {
        }

        public void InsertVertices(LinkedList<Vertex> insertVertices)
        {
            LinkedListNode<Vertex>? currentNode = _vertices.First;
            LinkedListNode<Vertex>? currInsertNode = insertVertices.First;
            uint orderCount = 0;

            while (currentNode != null)
            {
                currentNode.Value.Order = orderCount;
                while (currInsertNode is not null &&
                    currentNode is not null &&
                    currInsertNode.Value.Order == currentNode.Value.Order)
                {
                    _vertices.AddBefore(currentNode, currInsertNode.Value);
                    orderCount++;
                    currInsertNode = currInsertNode.Next;
                    currentNode.Value.Order = orderCount;
                }

                orderCount++;
                currentNode = currentNode.Next;
            }
        }
    }
}
