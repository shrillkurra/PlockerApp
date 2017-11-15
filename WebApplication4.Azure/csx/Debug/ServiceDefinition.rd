<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WebApplication4.Azure" generation="1" functional="0" release="0" Id="61184025-8ada-4cb1-9275-ae533138c644" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WebApplication4.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebApplication4:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/LB:WebApplication4:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebApplication4:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/MapWebApplication4:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebApplication4Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/MapWebApplication4Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebApplication4:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebApplication4:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebApplication4Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebApplication4" generation="1" functional="0" release="0" software="C:\Users\Srilu\Source\Repos\WebApplication4\WebApplication4.Azure\csx\Debug\roles\WebApplication4" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebApplication4&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebApplication4&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4Instances" />
            <sCSPolicyUpdateDomainMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WebApplication4UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WebApplication4FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WebApplication4Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="c91d3dd2-0cf6-46bb-aa10-1b18fcc58549" ref="Microsoft.RedDog.Contract\ServiceContract\WebApplication4.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="3eafb01e-129e-4613-8b42-dc5f28b5f493" ref="Microsoft.RedDog.Contract\Interface\WebApplication4:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WebApplication4.Azure/WebApplication4.AzureGroup/WebApplication4:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>