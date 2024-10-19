using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class OmnicrmContext : DbContext
{
    public OmnicrmContext()
    {
    }

    public OmnicrmContext(DbContextOptions<OmnicrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accounting> Accountings { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<Communication> Communications { get; set; }

    public virtual DbSet<CommunicationChannel> CommunicationChannels { get; set; }

    public virtual DbSet<CommunicationChannelDefinition> CommunicationChannelDefinitions { get; set; }

    public virtual DbSet<CommunicationRepresentative> CommunicationRepresentatives { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<ConnectionType> ConnectionTypes { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<ConversationStatus> ConversationStatuses { get; set; }

    public virtual DbSet<CorrespondenceType> CorrespondenceTypes { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerContactInfo> CustomerContactInfos { get; set; }

    public virtual DbSet<CustomerInquiry> CustomerInquiries { get; set; }

    public virtual DbSet<CustomerInquiryStatus> CustomerInquiryStatuses { get; set; }

    public virtual DbSet<CustomerSetting> CustomerSettings { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentDetail> DocumentDetails { get; set; }

    public virtual DbSet<DocumentItem> DocumentItems { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<LogAction> LogActions { get; set; }

    public virtual DbSet<MarketingCampaign> MarketingCampaigns { get; set; }

    public virtual DbSet<MarketingCampaignStatus> MarketingCampaignStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<QualificationDegree> QualificationDegrees { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<ServiceRequestStatus> ServiceRequestStatuses { get; set; }

    public virtual DbSet<StatusTask> StatusTasks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=185.145.252.191;Initial Catalog=omnicrm;Persist Security Info=True;User ID=omnicrm_login;Password=Sql@0547417791;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounting>(entity =>
        {
            entity.HasKey(e => e.AccountingId).HasName("PK__Accounti__F309AA699EACD357");

            entity.ToTable("Accounting", tb =>
                {
                    tb.HasTrigger("trgAccountingDelete");
                    tb.HasTrigger("trgAccountingInsert");
                    tb.HasTrigger("trgAccountingUpdate");
                });

            entity.Property(e => e.AccountingId).HasColumnName("AccountingID");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.TransactionType).HasMaxLength(255);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2A1B8BB67B91");

            entity.ToTable("Address", tb =>
                {
                    tb.HasTrigger("trgAddressDelete");
                    tb.HasTrigger("trgAddressInsert");
                    tb.HasTrigger("trgAddressUpdate");
                });

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .HasColumnName("Address");
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Address_Customer");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.BankAccountId).HasName("PK__BankAcco__4FC8E4A19044B012");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trgBankAccountsDelete");
                    tb.HasTrigger("trgBankAccountsInsert");
                    tb.HasTrigger("trgBankAccountsUpdate");
                });

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(255);
            entity.Property(e => e.BankRoutingNumber).HasMaxLength(50);
            entity.Property(e => e.Branch).HasMaxLength(50);
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("IBAN");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Swiftcode)
                .HasMaxLength(50)
                .HasColumnName("SWIFTCode");
        });

        modelBuilder.Entity<Communication>(entity =>
        {
            entity.HasKey(e => e.CommunicationId).HasName("PK__Communic__53E5658FF9974274");

            entity.ToTable("Communication", tb =>
                {
                    tb.HasTrigger("trgCommunicationDelete");
                    tb.HasTrigger("trgCommunicationInsert");
                    tb.HasTrigger("trgCommunicationUpdate");
                });

            entity.Property(e => e.CommunicationId).HasColumnName("CommunicationID");
            entity.Property(e => e.ChannelTblId).HasColumnName("Channel_Tbl_ID");
            entity.Property(e => e.ConversationTblId).HasColumnName("Conversation_Tbl_ID");
            entity.Property(e => e.CorrespondenceTypeTblId).HasColumnName("CorrespondenceType_Tbl_ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ParentCommunicationTblId).HasColumnName("ParentCommunication_Tbl_ID");
            entity.Property(e => e.Subject).HasMaxLength(255);

            entity.HasOne(d => d.ChannelTbl).WithMany(p => p.Communications)
                .HasForeignKey(d => d.ChannelTblId)
                .HasConstraintName("FK_Communication_Channel_Tbl_ID");

            entity.HasOne(d => d.ConversationTbl).WithMany(p => p.Communications)
                .HasForeignKey(d => d.ConversationTblId)
                .HasConstraintName("FK_Communication_Conversation_Tbl_ID");

            entity.HasOne(d => d.CorrespondenceTypeTbl).WithMany(p => p.Communications)
                .HasForeignKey(d => d.CorrespondenceTypeTblId)
                .HasConstraintName("FK_Communication_CorrespondenceType_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Communications)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Communication_Customer");

            entity.HasOne(d => d.ParentCommunicationTbl).WithMany(p => p.InverseParentCommunicationTbl)
                .HasForeignKey(d => d.ParentCommunicationTblId)
                .HasConstraintName("FK_Communication_ParentCommunication_Tbl_ID");
        });

        modelBuilder.Entity<CommunicationChannel>(entity =>
        {
            entity.HasKey(e => e.ChannelId).HasName("PK__Communic__38C3E8F4EEB1FBCF");

            entity.ToTable("CommunicationChannel", tb =>
                {
                    tb.HasTrigger("trgCommunicationChannelDelete");
                    tb.HasTrigger("trgCommunicationChannelInsert");
                    tb.HasTrigger("trgCommunicationChannelUpdate");
                });

            entity.Property(e => e.ChannelId).HasColumnName("ChannelID");
            entity.Property(e => e.ChannelDefinitionTblId).HasColumnName("ChannelDefinition_Tbl_ID");
            entity.Property(e => e.ChannelName).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.ChannelDefinitionTbl).WithMany(p => p.CommunicationChannels)
                .HasForeignKey(d => d.ChannelDefinitionTblId)
                .HasConstraintName("FK_CommunicationChannel_ChannelDefinition_Tbl_ID");
        });

        modelBuilder.Entity<CommunicationChannelDefinition>(entity =>
        {
            entity.HasKey(e => e.ChannelDefinitionId).HasName("PK__Communic__4474B638A1DCB41D");

            entity.ToTable("CommunicationChannelDefinition", tb =>
                {
                    tb.HasTrigger("trgCommunicationChannelDefinitionDelete");
                    tb.HasTrigger("trgCommunicationChannelDefinitionInsert");
                    tb.HasTrigger("trgCommunicationChannelDefinitionUpdate");
                });

            entity.Property(e => e.ChannelDefinitionId).HasColumnName("ChannelDefinitionID");
            entity.Property(e => e.ChannelName).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<CommunicationRepresentative>(entity =>
        {
            entity.HasKey(e => new { e.CommunicationTblId, e.CustomerTblId }).HasName("PK__Communic__947BC3DE3A261449");

            entity.ToTable("CommunicationRepresentative", tb =>
                {
                    tb.HasTrigger("trgCommunicationRepresentativeDelete");
                    tb.HasTrigger("trgCommunicationRepresentativeInsert");
                    tb.HasTrigger("trgCommunicationRepresentativeUpdate");
                });

            entity.HasIndex(e => new { e.CommunicationTblId, e.IsMainRepresentative }, "UQ_CommunicationRepresentative_MainRepresentative").IsUnique();

            entity.Property(e => e.CommunicationTblId).HasColumnName("Communication_Tbl_ID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");

            entity.HasOne(d => d.CommunicationTbl).WithMany(p => p.CommunicationRepresentatives)
                .HasForeignKey(d => d.CommunicationTblId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunicationRepresentative_Communication_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.CommunicationRepresentatives)
                .HasForeignKey(d => d.CustomerTblId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunicationRepresentative_Customer");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.ConnectionId).HasName("PK__Connecti__404A64F31F82F731");

            entity.ToTable("Connection", tb =>
                {
                    tb.HasTrigger("trgConnectionDelete");
                    tb.HasTrigger("trgConnectionInsert");
                    tb.HasTrigger("trgConnectionUpdate");
                });

            entity.Property(e => e.ConnectionId).HasColumnName("ConnectionID");
            entity.Property(e => e.ConnectionTypeTblId).HasColumnName("ConnectionType_Tbl_ID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.RelatedCustomerTblId).HasColumnName("RelatedCustomer_Tbl_ID");

            entity.HasOne(d => d.ConnectionTypeTbl).WithMany(p => p.Connections)
                .HasForeignKey(d => d.ConnectionTypeTblId)
                .HasConstraintName("FK_Connection_ConnectionType_Tbl_ID");
        });

        modelBuilder.Entity<ConnectionType>(entity =>
        {
            entity.HasKey(e => e.ConnectionTypeId).HasName("PK__Connecti__69EB7425CE54002F");

            entity.ToTable("ConnectionType", tb =>
                {
                    tb.HasTrigger("trgConnectionTypeDelete");
                    tb.HasTrigger("trgConnectionTypeInsert");
                    tb.HasTrigger("trgConnectionTypeUpdate");
                });

            entity.Property(e => e.ConnectionTypeId).HasColumnName("ConnectionTypeID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C6625BBBD1D1A1A");

            entity.ToTable("Contact", tb =>
                {
                    tb.HasTrigger("trgContactDelete");
                    tb.HasTrigger("trgContactInsert");
                    tb.HasTrigger("trgContactUpdate");
                });

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.ContactInfoTblId).HasColumnName("ContactInfo_Tbl_ID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);

            entity.HasOne(d => d.ContactInfoTbl).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactInfoTblId)
                .HasConstraintName("FK_Contact_ContactInfo_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Contact_Customer");
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.ContactInfoId).HasName("PK__ContactI__7B7333D9FC11567F");

            entity.ToTable("ContactInfo", tb =>
                {
                    tb.HasTrigger("trgContactInfoDelete");
                    tb.HasTrigger("trgContactInfoInsert");
                    tb.HasTrigger("trgContactInfoUpdate");
                });

            entity.Property(e => e.ContactInfoId).HasColumnName("ContactInfoID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Info).HasMaxLength(255);
            entity.Property(e => e.InfoType).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.ConversationId).HasName("PK__Conversa__C050D89726EEB4D8");

            entity.ToTable("Conversation", tb =>
                {
                    tb.HasTrigger("trgConversationDelete");
                    tb.HasTrigger("trgConversationInsert");
                    tb.HasTrigger("trgConversationUpdate");
                });

            entity.Property(e => e.ConversationId).HasColumnName("ConversationID");
            entity.Property(e => e.CallEndTime).HasColumnType("datetime");
            entity.Property(e => e.CallStartTime).HasColumnType("datetime");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasMany(d => d.ConversationStatusTbls).WithMany(p => p.ConversationTbls)
                .UsingEntity<Dictionary<string, object>>(
                    "ConversationStatusMapping",
                    r => r.HasOne<ConversationStatus>().WithMany()
                        .HasForeignKey("ConversationStatusTblId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ConversationStatusMapping_ConversationStatus_Tbl_ID"),
                    l => l.HasOne<Conversation>().WithMany()
                        .HasForeignKey("ConversationTblId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ConversationStatusMapping_Conversation_Tbl_ID"),
                    j =>
                    {
                        j.HasKey("ConversationTblId", "ConversationStatusTblId").HasName("PK__Conversa__69470FBCBAB52105");
                        j.ToTable("ConversationStatusMapping", tb =>
                            {
                                tb.HasTrigger("trgConversationStatusMappingDelete");
                                tb.HasTrigger("trgConversationStatusMappingInsert");
                                tb.HasTrigger("trgConversationStatusMappingUpdate");
                            });
                        j.IndexerProperty<int>("ConversationTblId").HasColumnName("Conversation_Tbl_ID");
                        j.IndexerProperty<int>("ConversationStatusTblId").HasColumnName("ConversationStatus_Tbl_ID");
                    });
        });

        modelBuilder.Entity<ConversationStatus>(entity =>
        {
            entity.HasKey(e => e.ConversationStatusId).HasName("PK__Conversa__68FE720B9952087C");

            entity.ToTable("ConversationStatus", tb =>
                {
                    tb.HasTrigger("trgConversationStatusDelete");
                    tb.HasTrigger("trgConversationStatusInsert");
                    tb.HasTrigger("trgConversationStatusUpdate");
                });

            entity.Property(e => e.ConversationStatusId).HasColumnName("ConversationStatusID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsConversationOpen).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<CorrespondenceType>(entity =>
        {
            entity.HasKey(e => e.CorrespondenceTypeId).HasName("PK__Correspo__A3CA57D5C89100C1");

            entity.ToTable("CorrespondenceType", tb =>
                {
                    tb.HasTrigger("trgCorrespondenceTypeDelete");
                    tb.HasTrigger("trgCorrespondenceTypeInsert");
                    tb.HasTrigger("trgCorrespondenceTypeUpdate");
                });

            entity.Property(e => e.CorrespondenceTypeId).HasColumnName("CorrespondenceTypeID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.CreditCardId).HasName("PK__CreditCa__6EB1F510ADF480D4");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_AfterDelete_CreditCards");
                    tb.HasTrigger("trg_AfterInsert_CreditCards");
                    tb.HasTrigger("trg_AfterUpdate_CreditCards");
                });

            entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");
            entity.Property(e => e.CardHolderName).HasMaxLength(255);
            entity.Property(e => e.CardNumber).HasMaxLength(16);
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.Cvv)
                .HasMaxLength(4)
                .HasColumnName("CVV");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.CreditCards)
                .HasForeignKey(d => d.CustomerTblId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreditCards_Customer");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer", tb =>
                {
                    tb.HasTrigger("trgCustomerDelete");
                    tb.HasTrigger("trgCustomerInsert");
                    tb.HasTrigger("trgCustomerUpdate");
                });

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTypeTblId).HasColumnName("CustomerType_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.CustomerTypeTbl).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeTblId)
                .HasConstraintName("FK_Customer_CustomerType_Tbl_ID");
        });

        modelBuilder.Entity<CustomerContactInfo>(entity =>
        {
            entity.HasKey(e => e.CustomerContactInfoId).HasName("PK__Customer__8944EBE8C60D188D");

            entity.ToTable("CustomerContactInfo", tb =>
                {
                    tb.HasTrigger("trgCustomerContactInfoDelete");
                    tb.HasTrigger("trgCustomerContactInfoInsert");
                    tb.HasTrigger("trgCustomerContactInfoUpdate");
                });

            entity.Property(e => e.CustomerContactInfoId).HasColumnName("CustomerContactInfoID");
            entity.Property(e => e.ContactInfoTblId).HasColumnName("ContactInfo_Tbl_ID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.ContactInfoTbl).WithMany(p => p.CustomerContactInfos)
                .HasForeignKey(d => d.ContactInfoTblId)
                .HasConstraintName("FK_UserContactInfo_ContactInfo_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.CustomerContactInfos)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_CustomerContactInfo_Customer");
        });

        modelBuilder.Entity<CustomerInquiry>(entity =>
        {
            entity.HasKey(e => e.InquiryId).HasName("PK__Customer__05E6E7EFC92040C7");

            entity.ToTable("CustomerInquiry", tb =>
                {
                    tb.HasTrigger("trgCustomerInquiryDelete");
                    tb.HasTrigger("trgCustomerInquiryInsert");
                    tb.HasTrigger("trgCustomerInquiryUpdate");
                });

            entity.Property(e => e.InquiryId).HasColumnName("InquiryID");
            entity.Property(e => e.CustomerInquiryStatusTblId).HasColumnName("CustomerInquiryStatus_Tbl_ID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.InquiryType).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CustomerInquiryStatusTbl).WithMany(p => p.CustomerInquiries)
                .HasForeignKey(d => d.CustomerInquiryStatusTblId)
                .HasConstraintName("FK_CustomerInquiry_CustomerInquiryStatus_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.CustomerInquiries)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_CustomerInquiry_Customer");
        });

        modelBuilder.Entity<CustomerInquiryStatus>(entity =>
        {
            entity.HasKey(e => e.CustomerInquiryStatusId).HasName("PK__Customer__02998973B48D7C6E");

            entity.ToTable("CustomerInquiryStatus", tb =>
                {
                    tb.HasTrigger("trgCustomerInquiryStatusDelete");
                    tb.HasTrigger("trgCustomerInquiryStatusInsert");
                    tb.HasTrigger("trgCustomerInquiryStatusUpdate");
                });

            entity.Property(e => e.CustomerInquiryStatusId).HasColumnName("CustomerInquiryStatusID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerSetting>(entity =>
        {
            entity.HasKey(e => e.SetupId).HasName("PK__Customer__C9C734B322CE03F6");

            entity.ToTable("CustomerSetting", tb =>
                {
                    tb.HasTrigger("trgCustomerSettingDelete");
                    tb.HasTrigger("trgCustomerSettingInsert");
                    tb.HasTrigger("trgCustomerSettingUpdate");
                });

            entity.Property(e => e.SetupId).HasColumnName("SetupID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.SetupName).HasMaxLength(50);
            entity.Property(e => e.SetupValue).HasMaxLength(255);

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.CustomerSettings)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_CustomerSetting_Customer");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("PK__Customer__958B614C6D16B221");

            entity.ToTable("CustomerType", tb =>
                {
                    tb.HasTrigger("trgCustomerTypeDelete");
                    tb.HasTrigger("trgCustomerTypeInsert");
                    tb.HasTrigger("trgCustomerTypeUpdate");
                });

            entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6F327BCAFB");

            entity.ToTable("Document", tb =>
                {
                    tb.HasTrigger("trgDocumentDelete");
                    tb.HasTrigger("trgDocumentInsert");
                    tb.HasTrigger("trgDocumentUpdate");
                });

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.CommunicationTblId).HasColumnName("Communication_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DocumentPath).HasMaxLength(255);
            entity.Property(e => e.DocumentTypeTblId).HasColumnName("DocumentType_Tbl_ID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CommunicationTbl).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CommunicationTblId)
                .HasConstraintName("FK_Document_Communication_Tbl_ID");

            entity.HasOne(d => d.DocumentTypeTbl).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeTblId)
                .HasConstraintName("FK_Document_DocumentType_Tbl_ID");
        });

        modelBuilder.Entity<DocumentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3213E83FF0874824");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_DocumentDetails_Delete");
                    tb.HasTrigger("trg_DocumentDetails_Insert");
                    tb.HasTrigger("trg_DocumentDetails_Update");
                });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Afterdiscount)
                .HasMaxLength(50)
                .HasColumnName("afterdiscount");
            entity.Property(e => e.AgentId)
                .HasMaxLength(50)
                .HasColumnName("agent_id");
            entity.Property(e => e.CancellationReason).HasColumnName("cancellation_reason");
            entity.Property(e => e.ClientAddress)
                .HasMaxLength(255)
                .HasColumnName("client_address");
            entity.Property(e => e.ClientId)
                .HasMaxLength(50)
                .HasColumnName("client_id");
            entity.Property(e => e.ClientIdno)
                .HasMaxLength(50)
                .HasColumnName("client_idno");
            entity.Property(e => e.ClientName)
                .HasMaxLength(255)
                .HasColumnName("client_name");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .HasColumnName("currency");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(50)
                .HasColumnName("currency_id");
            entity.Property(e => e.CustomClientId)
                .HasMaxLength(50)
                .HasColumnName("custom_client_id");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Dateissued).HasColumnName("dateissued");
            entity.Property(e => e.DocTitle).HasColumnName("doc_title");
            entity.Property(e => e.DocUrl).HasColumnName("doc_url");
            entity.Property(e => e.Docnum)
                .HasMaxLength(50)
                .HasColumnName("docnum");
            entity.Property(e => e.Doctype)
                .HasMaxLength(50)
                .HasColumnName("doctype");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("employee_id");
            entity.Property(e => e.FactoringStatus)
                .HasMaxLength(50)
                .HasColumnName("factoring_status");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Hwc).HasColumnName("hwc");
            entity.Property(e => e.Imported)
                .HasMaxLength(50)
                .HasColumnName("imported");
            entity.Property(e => e.IncomeType)
                .HasMaxLength(50)
                .HasColumnName("income_type");
            entity.Property(e => e.IncomeTypeId)
                .HasMaxLength(50)
                .HasColumnName("income_type_id");
            entity.Property(e => e.InternalComments).HasColumnName("internal_comments");
            entity.Property(e => e.InvoiceReferenceNumber)
                .HasMaxLength(50)
                .HasColumnName("invoice_reference_number");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsCancellable)
                .HasMaxLength(50)
                .HasColumnName("is_cancellable");
            entity.Property(e => e.IsCancellation)
                .HasMaxLength(50)
                .HasColumnName("is_cancellation");
            entity.Property(e => e.IsCancelled)
                .HasMaxLength(50)
                .HasColumnName("is_cancelled");
            entity.Property(e => e.Lang)
                .HasMaxLength(50)
                .HasColumnName("lang");
            entity.Property(e => e.Paydate).HasColumnName("paydate");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.Rate)
                .HasMaxLength(50)
                .HasColumnName("rate");
            entity.Property(e => e.Remainingsum)
                .HasMaxLength(50)
                .HasColumnName("remainingsum");
            entity.Property(e => e.RemainingsumBeforeVat)
                .HasMaxLength(50)
                .HasColumnName("remainingsum_before_vat");
            entity.Property(e => e.Roundup)
                .HasMaxLength(50)
                .HasColumnName("roundup");
            entity.Property(e => e.SalesmanId)
                .HasMaxLength(50)
                .HasColumnName("salesman_id");
            entity.Property(e => e.SelfInvoice)
                .HasMaxLength(50)
                .HasColumnName("self_invoice");
            entity.Property(e => e.ShippingAddress).HasColumnName("shipping_address");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TaxExempt)
                .HasMaxLength(50)
                .HasColumnName("tax_exempt");
            entity.Property(e => e.Timeissued)
                .HasMaxLength(50)
                .HasColumnName("timeissued");
            entity.Property(e => e.Total)
                .HasMaxLength(50)
                .HasColumnName("total");
            entity.Property(e => e.Totalsum)
                .HasMaxLength(50)
                .HasColumnName("totalsum");
            entity.Property(e => e.TotalsumExempt)
                .HasMaxLength(50)
                .HasColumnName("totalsum_exempt");
            entity.Property(e => e.Totalvat)
                .HasMaxLength(50)
                .HasColumnName("totalvat");
            entity.Property(e => e.Totalwithvat)
                .HasMaxLength(50)
                .HasColumnName("totalwithvat");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("user_id");
            entity.Property(e => e.VatId)
                .HasMaxLength(50)
                .HasColumnName("vat_id");
            entity.Property(e => e.VatPercent)
                .HasMaxLength(50)
                .HasColumnName("vat_percent");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.CustomerTblId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Customer_Tbl_ID_fk");
        });

        modelBuilder.Entity<DocumentItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3213E83F67614B68");

            entity.ToTable("DocumentItem", tb =>
                {
                    tb.HasTrigger("trg_DeleteDocumentItem");
                    tb.HasTrigger("trg_InsertDocumentItem");
                    tb.HasTrigger("trg_UpdateDocumentItem");
                });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Afterdiscount)
                .HasMaxLength(50)
                .HasColumnName("afterdiscount");
            entity.Property(e => e.ClientAddress)
                .HasMaxLength(255)
                .HasColumnName("client_address");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(255)
                .HasColumnName("client_email");
            entity.Property(e => e.ClientId)
                .HasMaxLength(50)
                .HasColumnName("client_id");
            entity.Property(e => e.ClientIdno)
                .HasMaxLength(50)
                .HasColumnName("client_idno");
            entity.Property(e => e.ClientName)
                .HasMaxLength(255)
                .HasColumnName("client_name");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .HasColumnName("currency");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(50)
                .HasColumnName("currency_id");
            entity.Property(e => e.CustomClientId)
                .HasMaxLength(50)
                .HasColumnName("custom_client_id");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Dateissued).HasColumnName("dateissued");
            entity.Property(e => e.Discount)
                .HasMaxLength(50)
                .HasColumnName("discount");
            entity.Property(e => e.DocTitle).HasColumnName("doc_title");
            entity.Property(e => e.DocUrl).HasColumnName("doc_url");
            entity.Property(e => e.Docnum)
                .HasMaxLength(50)
                .HasColumnName("docnum");
            entity.Property(e => e.Doctype)
                .HasMaxLength(50)
                .HasColumnName("doctype");
            entity.Property(e => e.DocumentDetailsTblId).HasColumnName("DocumentDetails_Tbl_ID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("employee_id");
            entity.Property(e => e.FactoringStatus)
                .HasMaxLength(50)
                .HasColumnName("factoring_status");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.HasBarter)
                .HasMaxLength(50)
                .HasColumnName("has_barter");
            entity.Property(e => e.HasBt)
                .HasMaxLength(50)
                .HasColumnName("has_bt");
            entity.Property(e => e.HasCash)
                .HasMaxLength(50)
                .HasColumnName("has_cash");
            entity.Property(e => e.HasCc)
                .HasMaxLength(50)
                .HasColumnName("has_cc");
            entity.Property(e => e.HasCheques)
                .HasMaxLength(50)
                .HasColumnName("has_cheques");
            entity.Property(e => e.HasHk)
                .HasMaxLength(50)
                .HasColumnName("has_hk");
            entity.Property(e => e.HasPp)
                .HasMaxLength(50)
                .HasColumnName("has_pp");
            entity.Property(e => e.Imported)
                .HasMaxLength(50)
                .HasColumnName("imported");
            entity.Property(e => e.IncomeType)
                .HasMaxLength(50)
                .HasColumnName("income_type");
            entity.Property(e => e.IncomeTypeId)
                .HasMaxLength(50)
                .HasColumnName("income_type_id");
            entity.Property(e => e.InvoiceReferenceNumber)
                .HasMaxLength(50)
                .HasColumnName("invoice_reference_number");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsCancellation)
                .HasMaxLength(50)
                .HasColumnName("is_cancellation");
            entity.Property(e => e.IsCancelled)
                .HasMaxLength(50)
                .HasColumnName("is_cancelled");
            entity.Property(e => e.Oprintedv2)
                .HasMaxLength(50)
                .HasColumnName("oprintedv2");
            entity.Property(e => e.Paid)
                .HasMaxLength(50)
                .HasColumnName("paid");
            entity.Property(e => e.PosId)
                .HasMaxLength(50)
                .HasColumnName("pos_id");
            entity.Property(e => e.Rate)
                .HasMaxLength(50)
                .HasColumnName("rate");
            entity.Property(e => e.RemainingsumBeforeVat)
                .HasMaxLength(50)
                .HasColumnName("remainingsum_before_vat");
            entity.Property(e => e.Roundup)
                .HasMaxLength(50)
                .HasColumnName("roundup");
            entity.Property(e => e.SalesmanId)
                .HasMaxLength(50)
                .HasColumnName("salesman_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TaxExempt)
                .HasMaxLength(50)
                .HasColumnName("tax_exempt");
            entity.Property(e => e.Timeissued)
                .HasMaxLength(50)
                .HasColumnName("timeissued");
            entity.Property(e => e.Total)
                .HasMaxLength(50)
                .HasColumnName("total");
            entity.Property(e => e.Totalpaid)
                .HasMaxLength(50)
                .HasColumnName("totalpaid");
            entity.Property(e => e.Totalsum)
                .HasMaxLength(50)
                .HasColumnName("totalsum");
            entity.Property(e => e.Totalvat)
                .HasMaxLength(50)
                .HasColumnName("totalvat");
            entity.Property(e => e.Totalwht)
                .HasMaxLength(50)
                .HasColumnName("totalwht");
            entity.Property(e => e.Totalwithvat)
                .HasMaxLength(50)
                .HasColumnName("totalwithvat");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("user_id");
            entity.Property(e => e.VatPercent)
                .HasMaxLength(50)
                .HasColumnName("vat_percent");

            entity.HasOne(d => d.DocumentDetailsTbl).WithMany(p => p.DocumentItems)
                .HasForeignKey(d => d.DocumentDetailsTblId)
                .HasConstraintName("FK_DocumentItem_DocumentDetails");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId).HasName("PK__Document__DBA390C166BEDC6E");

            entity.ToTable("DocumentType", tb =>
                {
                    tb.HasTrigger("trgDocumentTypeDelete");
                    tb.HasTrigger("trgDocumentTypeInsert");
                    tb.HasTrigger("trgDocumentTypeUpdate");
                });

            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expense__1445CFF3662FC3A7");

            entity.ToTable("Expense", tb =>
                {
                    tb.HasTrigger("trgExpenseDelete");
                    tb.HasTrigger("trgExpenseInsert");
                    tb.HasTrigger("trgExpenseUpdate");
                });

            entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ExpenseDate).HasColumnType("datetime");
            entity.Property(e => e.ExpenseDescription).HasMaxLength(255);
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Expense_Customer");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Inventor__B40CC6ED94A38132");

            entity.ToTable("Inventory", tb =>
                {
                    tb.HasTrigger("trg_Inventory_Delete");
                    tb.HasTrigger("trg_Inventory_Insert");
                    tb.HasTrigger("trg_Inventory_Update");
                });

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BatchNumber).HasMaxLength(255);
            entity.Property(e => e.Certification).HasMaxLength(255);
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DocumentItemTblId).HasColumnName("DocumentItem_Tbl_ID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PriceBeforeTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.UnitMeasure).HasMaxLength(50);
            entity.Property(e => e.Warehouse).HasMaxLength(255);

            entity.HasOne(d => d.DocumentItemTbl).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.DocumentItemTblId)
                .HasConstraintName("FK_DocumentItem_Tbl_ID");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Log__5E5499A80699ED4F");

            entity.ToTable("Log", tb =>
                {
                    tb.HasTrigger("trgLogDelete");
                    tb.HasTrigger("trgLogInsert");
                    tb.HasTrigger("trgLogUpdate");
                });

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LogActionTblId).HasColumnName("LogAction_Tbl_ID");
            entity.Property(e => e.Machine).HasMaxLength(255);
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.TableName).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.LogActionTbl).WithMany(p => p.Logs)
                .HasForeignKey(d => d.LogActionTblId)
                .HasConstraintName("FK_Log_LogAction_Tbl_ID");
        });

        modelBuilder.Entity<LogAction>(entity =>
        {
            entity.HasKey(e => e.LogActionId).HasName("PK__LogActio__1EBD4AE68F896E99");

            entity.ToTable("LogAction", tb =>
                {
                    tb.HasTrigger("trgLogActionDelete");
                    tb.HasTrigger("trgLogActionInsert");
                    tb.HasTrigger("trgLogActionUpdate");
                });

            entity.Property(e => e.LogActionId).HasColumnName("LogActionID");
            entity.Property(e => e.ActionName).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<MarketingCampaign>(entity =>
        {
            entity.HasKey(e => e.MarketingCampaignId).HasName("PK__Marketin__A36E42EB294C35B8");

            entity.ToTable("MarketingCampaign", tb =>
                {
                    tb.HasTrigger("trgMarketingCampaignDelete");
                    tb.HasTrigger("trgMarketingCampaignInsert");
                    tb.HasTrigger("trgMarketingCampaignUpdate");
                });

            entity.Property(e => e.MarketingCampaignId).HasColumnName("MarketingCampaignID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.MarketingCampaignStatusTblId).HasColumnName("MarketingCampaignStatus_Tbl_ID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.MarketingCampaignStatusTbl).WithMany(p => p.MarketingCampaigns)
                .HasForeignKey(d => d.MarketingCampaignStatusTblId)
                .HasConstraintName("FK_MarketingCampaign_MarketingCampaignStatus_Tbl_ID");
        });

        modelBuilder.Entity<MarketingCampaignStatus>(entity =>
        {
            entity.HasKey(e => e.MarketingCampaignStatusId).HasName("PK__Marketin__C542F2B5F3D16111");

            entity.ToTable("MarketingCampaignStatus", tb =>
                {
                    tb.HasTrigger("trgMarketingCampaignStatusDelete");
                    tb.HasTrigger("trgMarketingCampaignStatusInsert");
                    tb.HasTrigger("trgMarketingCampaignStatusUpdate");
                });

            entity.Property(e => e.MarketingCampaignStatusId).HasColumnName("MarketingCampaignStatusID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED1D82244B");

            entity.ToTable("Product", tb =>
                {
                    tb.HasTrigger("trgProductDelete");
                    tb.HasTrigger("trgProductInsert");
                    tb.HasTrigger("trgProductUpdate");
                });

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.PurchaseTblId).HasColumnName("Purchase_Tbl_ID");

            entity.HasOne(d => d.PurchaseTbl).WithMany(p => p.Products)
                .HasForeignKey(d => d.PurchaseTblId)
                .HasConstraintName("FK_Product_Purchase_Tbl_ID");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Property__70C9A7552494B979");

            entity.ToTable("Property", tb =>
                {
                    tb.HasTrigger("trgPropertyDelete");
                    tb.HasTrigger("trgPropertyInsert");
                    tb.HasTrigger("trgPropertyUpdate");
                });

            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PropertyName).HasMaxLength(50);
            entity.Property(e => e.PropertyValue).HasMaxLength(255);

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Properties)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Property_Customer");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__6B0A6BDEE4EAD51F");

            entity.ToTable("Purchase", tb =>
                {
                    tb.HasTrigger("trgPurchaseDelete");
                    tb.HasTrigger("trgPurchaseInsert");
                    tb.HasTrigger("trgPurchaseUpdate");
                });

            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Purchase_Customer");
        });

        modelBuilder.Entity<QualificationDegree>(entity =>
        {
            entity.HasKey(e => e.QualificationDegreeId).HasName("PK__Qualific__3296B1D24B54E94F");

            entity.ToTable("QualificationDegree", tb =>
                {
                    tb.HasTrigger("trgQualificationDegreeDelete");
                    tb.HasTrigger("trgQualificationDegreeInsert");
                    tb.HasTrigger("trgQualificationDegreeUpdate");
                });

            entity.Property(e => e.QualificationDegreeId).HasColumnName("QualificationDegreeID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DateOfAttainment).HasColumnType("datetime");
            entity.Property(e => e.Degree).HasMaxLength(50);
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.QualificationDegrees)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_QualificationDegree_Customer");
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(e => e.ServiceRequestId).HasName("PK__ServiceR__790F6CABE9D267FB");

            entity.ToTable("ServiceRequest", tb =>
                {
                    tb.HasTrigger("trgServiceRequestDelete");
                    tb.HasTrigger("trgServiceRequestInsert");
                    tb.HasTrigger("trgServiceRequestUpdate");
                });

            entity.Property(e => e.ServiceRequestId).HasColumnName("ServiceRequestID");
            entity.Property(e => e.AssignedTo).HasMaxLength(255);
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.RequestType).HasMaxLength(255);
            entity.Property(e => e.ServiceRequestStatusTblId).HasColumnName("ServiceRequestStatus_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_ServiceRequest_Customer");

            entity.HasOne(d => d.ServiceRequestStatusTbl).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.ServiceRequestStatusTblId)
                .HasConstraintName("FK_ServiceRequest_ServiceRequestStatus_Tbl_ID");
        });

        modelBuilder.Entity<ServiceRequestStatus>(entity =>
        {
            entity.HasKey(e => e.ServiceRequestStatusId).HasName("PK__ServiceR__A2E09C25BE75DB28");

            entity.ToTable("ServiceRequestStatus", tb =>
                {
                    tb.HasTrigger("trgServiceRequestStatusDelete");
                    tb.HasTrigger("trgServiceRequestStatusInsert");
                    tb.HasTrigger("trgServiceRequestStatusUpdate");
                });

            entity.Property(e => e.ServiceRequestStatusId).HasColumnName("ServiceRequestStatusID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusTask>(entity =>
        {
            entity.HasKey(e => e.StatusTaskId).HasName("PK__StatusTa__4286FDEAA5B9366D");

            entity.ToTable("StatusTask", tb =>
                {
                    tb.HasTrigger("trgStatusTaskDelete");
                    tb.HasTrigger("trgStatusTaskInsert");
                    tb.HasTrigger("trgStatusTaskUpdate");
                });

            entity.Property(e => e.StatusTaskId).HasColumnName("StatusTaskID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Task__7C6949D1B75B8A85");

            entity.ToTable("Task", tb =>
                {
                    tb.HasTrigger("trgTaskDelete");
                    tb.HasTrigger("trgTaskInsert");
                    tb.HasTrigger("trgTaskUpdate");
                });

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.AssignedTo).HasMaxLength(255);
            entity.Property(e => e.ConversationTblId).HasColumnName("Conversation_Tbl_ID");
            entity.Property(e => e.CustomerTblId).HasColumnName("Customer_Tbl_ID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.StatusTaskTblId).HasColumnName("StatusTask_Tbl_ID");

            entity.HasOne(d => d.ConversationTbl).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ConversationTblId)
                .HasConstraintName("FK_Task_Conversation_Tbl_ID");

            entity.HasOne(d => d.CustomerTbl).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CustomerTblId)
                .HasConstraintName("FK_Task_Customer");

            entity.HasOne(d => d.StatusTaskTbl).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusTaskTblId)
                .HasConstraintName("FK_Task_StatusTask_Tbl_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
