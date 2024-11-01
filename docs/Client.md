# Client

This is the central entrypoint for all SDK interaction. The BoxClient houses all the API endpoints
divided across resource managers.

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [Additional headers](#additional-headers)
  - [As-User header](#as-user-header)
  - [Suppress notifications](#suppress-notifications)
  - [Custom headers](#custom-headers)
- [Custom Base URLs](#custom-base-urls)
- [Use Proxy for API calls](#use-proxy-for-api-calls)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# Additional headers

BoxClient provides a convenient methods, which allow passing additional headers, which will be included
in every API call made by the client.

## As-User header

The As-User header is used by enterprise admins to make API calls on behalf of their enterprise's users.
This requires the API request to pass an As-User: USER-ID header. For more details see the [documentation on As-User](https://developer.box.com/en/guides/authentication/oauth2/as-user/).

The following example assume that the client has been instantiated with an access token belonging to an admin-level user
or Service Account with appropriate privileges to make As-User calls.

Calling the `client.WithAsUserHeader()` method creates a new client to impersonate user with the provided ID.
All calls made with the new client will be made in context of the impersonated user, leaving the original client unmodified.

<!-- sample x_auth init_with_as_user_header -->

```c#
var userClient = client.WithAsUserHeader(useId: "1234567");
```

## Suppress notifications

If you are making administrative API calls (that is, your application has “Manage an Enterprise”
scope, and the user signing in is a co-admin with the correct "Edit settings for your company"
permission) then you can suppress both email and webhook notifications. This can be used, for
example, for a virus-scanning tool to download copies of everyone’s files in an enterprise,
without every collaborator on the file getting an email. All actions will still appear in users'
updates feed and audit logs.

> **Note:** This functionality is only available for approved applications.

Calling the `client.WithSuppressedNotifications()` method creates a new client.
For all calls made with the new client the notifications will be suppressed.

```c#
var newClient = client.WithSuppressedNotifications();
```

## Custom headers

You can also specify the custom set of headers, which will be included in every API call made by client.
Calling the `client.WithExtraHeaders()` method creates a new client, leaving the original client unmodified.

```c#
var extraHeaders = new Dictionary<string, string?>()
        {
           { "customHeader", "customValue" }
        };
var newClient = client.WithExtraHeaders(extraHeaders: extraHeaders);
```

# Custom Base URLs

You can also specify the custom base URLs, which will be used for API calls made by client.
Calling the `client.WithCustomBaseUrls()` method creates a new client, leaving the original client unmodified.

```c#
var newClient = client.WithCustomBaseUrls(new BaseUrls(
  baseUrl: "https://api.box2.com",
  uploadUrl: "https://upload.box.com/api",
  oauth2Url: "https://account.box.com/api/oauth2"
));
```

# Use Proxy for API calls

In order to use a proxy for API calls, calling the `client.WithProxy(proxyConfig)` method creates a new client, leaving the original client unmodified, with the username and password being optional.

```c#
var newClient = client.WithProxy(new ProxyConfig("http://proxy.com") { Username = "username", Password = "password", Domain = "example" });
```
