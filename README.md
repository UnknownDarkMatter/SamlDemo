
Le code source du projet :
https://saniteau.visualstudio.com/


pour que Saml2 fonctionne il faut installer le certificat dans les authorités racines de confiance
j'ai créé a la mano le sts.windows.net-accounts.accesscontrol.windows.net.cer
en recuperant le certificat a partir de https://login.microsoftonline.com/6034845f-1372-457d-8d8e-3ea438724be1/federationmetadata/2007-06/federationmetadata.xml
qui est donné dans l'app registration
prendre entityID="https://sts.windows.net/6034845f-1372-457d-8d8e-3ea438724be1/






##################### anciennes docs

"Saml2.Authentication" vs "Sustainsys.Saml2"

	https://saml2.sustainsys.com/en/v2/index.html

doc
	https://www.identityserver.com/articles/why-you-wouldn-t-use-saml-in-a-spa-and-mobile-app
	https://www.okta.com/fr/identity-101/saml-vs-oauth/
	
	an implementation all home made in old ASP.Net:
		https://blog.scottlogic.com/2015/11/19/oauth2-with-saml2.html
		
une piste 
	https://stackoverflow.com/questions/55025336/sustainsys-saml2-sample-for-asp-net-core-webapi-without-identity
	
	C:\Users\Sebastien\Downloads\OAuthWithSAMLAuthentication
	C:\Users\Sebastien\Downloads\Saml2-develop
	
	
	
	
	https://github.com/ITfoxtec/ITfoxtec.Identity.Saml2/blob/master/test/TestWebAppCore/Startup.cs