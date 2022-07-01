﻿using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class AuthenticationServer
{
    [DataMember(Name = "id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataMember(Name = "authenticationUrl")]
    public string? AuthenticationUrl { get; set; }
}