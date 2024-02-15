using System.Text.Json.Serialization;
using Unions;
using Serializer;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen;
using Box.Sdk.Gen.Managers;

namespace Box.Sdk.Gen {
    public class JwtConfig {
        /// <summary>
        /// App client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// App client secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Public key ID
        /// </summary>
        public string JwtKeyId { get; set; }

        /// <summary>
        /// Private key
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Passphrase
        /// </summary>
        public string PrivateKeyPassphrase { get; set; }

        /// <summary>
        /// Enterprise ID
        /// </summary>
        public string? EnterpriseId { get; set; } = default;

        /// <summary>
        /// User ID
        /// </summary>
        public string? UserId { get; set; } = default;

        public JwtAlgorithm? Algorithm { get; set; }

        public ITokenStorage TokenStorage { get; set; }

        public JwtConfig(string clientId, string clientSecret, string jwtKeyId, string privateKey, string privateKeyPassphrase, JwtAlgorithm? algorithm = default, ITokenStorage tokenStorage = default) {
            ClientId = clientId;
            ClientSecret = clientSecret;
            JwtKeyId = jwtKeyId;
            PrivateKey = privateKey;
            PrivateKeyPassphrase = privateKeyPassphrase;
            Algorithm = algorithm ?? JwtAlgorithm.Rs256;
            TokenStorage = tokenStorage ?? new InMemoryTokenStorage();
        }
        /// <summary>
        /// Create an auth instance as defined by a string content of JSON file downloaded from the Box Developer Console.
        /// See https://developer.box.com/en/guides/authentication/jwt/ for more information.
        /// </summary>
        /// <param name="configJsonString">
        /// String content of JSON file containing the configuration.
        /// </param>
        /// <param name="tokenStorage">
        /// Object responsible for storing token. If no custom implementation provided, the token will be stored in memory.g
        /// </param>
        public static JwtConfig FromConfigJsonString(string configJsonString, ITokenStorage? tokenStorage = null) {
            JwtConfigFile configJson = SimpleJsonSerializer.Deserialize<JwtConfigFile>(JsonUtils.JsonToSerializedData(text: configJsonString));
            JwtConfig newConfig = tokenStorage != null ? new JwtConfig(clientId: configJson.BoxAppSettings.ClientId, clientSecret: configJson.BoxAppSettings.ClientSecret, jwtKeyId: configJson.BoxAppSettings.AppAuth.PublicKeyId, privateKey: configJson.BoxAppSettings.AppAuth.PrivateKey, privateKeyPassphrase: configJson.BoxAppSettings.AppAuth.Passphrase, tokenStorage: tokenStorage) { EnterpriseId = configJson.EnterpriseId, UserId = configJson.UserId } : new JwtConfig(clientId: configJson.BoxAppSettings.ClientId, clientSecret: configJson.BoxAppSettings.ClientSecret, jwtKeyId: configJson.BoxAppSettings.AppAuth.PublicKeyId, privateKey: configJson.BoxAppSettings.AppAuth.PrivateKey, privateKeyPassphrase: configJson.BoxAppSettings.AppAuth.Passphrase) { EnterpriseId = configJson.EnterpriseId, UserId = configJson.UserId };
            return newConfig;
        }

        /// <summary>
        /// Create an auth instance as defined by a JSON file downloaded from the Box Developer Console.
        /// See https://developer.box.com/en/guides/authentication/jwt/ for more information.
        /// </summary>
        /// <param name="configFilePath">
        /// Path to the JSON file containing the configuration.
        /// </param>
        /// <param name="tokenStorage">
        /// Object responsible for storing token. If no custom implementation provided, the token will be stored in memory.
        /// </param>
        public static JwtConfig FromConfigFile(string configFilePath, ITokenStorage? tokenStorage = null) {
            string configJsonString = Utils.ReadTextFromFile(filepath: configFilePath);
            return JwtConfig.FromConfigJsonString(configJsonString: configJsonString, tokenStorage: tokenStorage);
        }

    }
}