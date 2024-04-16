﻿using System.ComponentModel;

namespace ShipErp.Core.Constants;
public static class Permissions
{
    public static class Dashboard
    {
        [Description("Xem dashboard")]
        public const string View = "Permissions.Dashboard.View";
    }
    public static class Roles
    {
        [Description("Xem quyền")]
        public const string View = "Permissions.Roles.View";
        [Description("Tạo mới quyền")]
        public const string Create = "Permissions.Roles.Create";
        [Description("Sửa quyền")]
        public const string Edit = "Permissions.Roles.Edit";
        [Description("Xóa quyền")]
        public const string Delete = "Permissions.Roles.Delete";
    }
    public static class Users
    {
        [Description("Xem người dùng")]
        public const string View = "Permissions.Users.View";
        [Description("Tạo người dùng")]
        public const string Create = "Permissions.Users.Create";
        [Description("Sửa người dùng")]
        public const string Edit = "Permissions.Users.Edit";
        [Description("Xóa người dùng")]
        public const string Delete = "Permissions.Users.Delete";
    }
    public static class Posts
    {
        [Description("Xem bài viết")]
        public const string View = "Permissions.Posts.View";
        [Description("Tạo bài viết")]
        public const string Create = "Permissions.Posts.Create";
        [Description("Sửa bài viết")]
        public const string Edit = "Permissions.Posts.Edit";
        [Description("Xóa bài viết")]
        public const string Delete = "Permissions.Posts.Delete";
    }
}
