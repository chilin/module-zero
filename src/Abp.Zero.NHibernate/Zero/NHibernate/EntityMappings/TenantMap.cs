using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.NHibernate.EntityMappings;

namespace Abp.Zero.NHibernate.EntityMappings
{
    /// <summary>
    /// Base class to map classes derived from <see cref="AbpTenant{TTenant,TUser}"/>
    /// </summary>
    /// <typeparam name="TTenant">Tenant type</typeparam>
    /// <typeparam name="TUser">User type</typeparam>
    public abstract class TenantMap<TTenant, TUser> : EntityMap<TTenant>
        where TTenant : AbpTenant<TTenant, TUser>
        where TUser : AbpUser<TTenant, TUser>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TenantMap()
            : base("AbpTenants")
        {
            References(x => x.Edition).Column("EditionId").Nullable();

            Map(x => x.TenancyName);
            Map(x => x.Name);
            Map(x => x.IsActive);

            this.MapFullAudited();

            Polymorphism.Explicit();
        }
    }
}