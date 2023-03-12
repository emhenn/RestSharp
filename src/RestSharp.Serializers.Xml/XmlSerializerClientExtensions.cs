//   Copyright (c) .NET Foundation and Contributors
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 

namespace RestSharp.Serializers.Xml;

[PublicAPI]
public static class XmlSerializerClientExtensions {
    public static SerializerConfig UseXmlSerializer(
        this SerializerConfig config,
        string?               xmlNamespace             = null,
        string?               rootElement              = null,
        bool                  useAttributeDeserializer = false
    ) {
        var xmlSerializer = new XmlSerializer {
            Namespace   = xmlNamespace,
            RootElement = rootElement
        };

        var xmlDeserializer = useAttributeDeserializer ? new XmlAttributeDeserializer() : new XmlDeserializer();

        var serializer = new XmlRestSerializer()
            .WithXmlSerializer(xmlSerializer)
            .WithXmlDeserializer(xmlDeserializer);

        return config.UseSerializer(() => serializer);
    }
}
