//  Copyright (c) .NET Foundation and Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace RestSharp.Extensions;

public static class HttpResponseExtensions {
    internal static Exception? MaybeException(this HttpResponseMessage httpResponse)
        => httpResponse.IsSuccessStatusCode
            ? null
#if NETSTANDARD || NETFRAMEWORK
            : new HttpRequestException($"Request failed with status code {httpResponse.StatusCode}");
#else
            : new HttpRequestException($"Request failed with status code {httpResponse.StatusCode}", null, httpResponse.StatusCode);
#endif
}
