Web Sample ReadMe

This demonstrates how to use AspNetWebApi2Helpers.Serialization package
to configure Json, Xml and Protobuf formatters to handle cyclical references.

The entities returned by the controllers have cyclical references:
Category references Product, and Product references Category. By default,
trying to serialize either one results in an exception.

1. Run the Web app in the browser
   - Click API, Get Categories, Test API, Send
   - You should see an error which describes a self-referencing loop

2. Add these NuGet packages:
   AspNetWebApi2Helpers.Serialization
   AspnetWebApi2Helpers.Serialization.Protobuf
   - If necessary include pre-released packages

3. Add code to WebApiConfig.Register:

	config.Formatters.JsonPreserveReferences();
	config.Formatters.XmlPreserveReferences();
	config.Formatters.ProtobufPreserveReferences(typeof(Category).Assembly);

4. Restart the web app and test the controller again
   - The action should return entities which contain cyclical references

NOTE: After building and/or running the web app, you may receive the following warning:
      "Found conflicts between different versions of the same dependent assembly."
	  Simply double-click on the warning in the VS 2013 Error List, and the correct
	  binding redirect will be added to web.config:

	<runtime>
		<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
			<dependentAssembly>
				<assemblyIdentity name="System.Net.Http.Formatting" publicKeyToken="31BF3856AD364E35" culture="neutral"/>
				<bindingRedirect oldVersion="0.0.0.0-5.2.2.0" newVersion="5.2.2.0"/>
			</dependentAssembly>
