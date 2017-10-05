using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Triangle.SharedKernel.Interfaces;

namespace Triangle.UserManagement.Core.Interfaces
{
    public interface IMessagePublisher
    {
        Task Publish(IApplicationEvent applicationEvent, string label = null, string correlationId = null);
    }
}