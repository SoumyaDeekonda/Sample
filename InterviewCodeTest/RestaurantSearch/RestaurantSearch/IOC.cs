using Autofac;
using Trainline.CardApi.Auditing.Repository;

namespace RestaurantSearch
{
    public class AuditingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(context => new AuditRepository(context.ResolveNamed<IConnectionFactory>("AuditingConnectionFactory")))
                .As<IAuditRepository>();

            builder
                .RegisterType<SqlServerAuditConnectionFactory>()
                .Named<IConnectionFactory>("AuditingConnectionFactory");

        }
    }
}