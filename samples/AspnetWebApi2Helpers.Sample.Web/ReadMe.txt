Web Sample ReadMe

This demonstrates how to use AspNetWebApi2Helpers.Serialization package
to configure Json, Xml and Protobuf formatters to handle cyclical references.

The entities returned by the controllers have cyclical references:
Category references Product, and Product references Category. By default,
trying to serialize either one results in an exception.

1. Run the Web app in the browser
   - Click API, Get Categories, Test API, Send
   - You should see an error which describes a self-referencing loop

2. Add the NuGet package: AspNetWebApi2Helpers.Serialization
   - If necessary include pre-released packages

3. Add code to WebApiConfig.Register:

	config.Formatters.JsonPreserveReferences();
	config.Formatters.XmlPreserveReferences();

4. Restart the web app and test the controller again
   - The action should return entities which contain cyclical references

