<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="NAVAzureCloudService" generation="1" functional="0" release="0" Id="af0fe190-43bc-4994-9969-2d8851e3d388" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="NAVAzureCloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WCFServiceWebRoleNAV:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/LB:WCFServiceWebRoleNAV:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WCFServiceWebRoleNAV:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/MapWCFServiceWebRoleNAV:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WCFServiceWebRoleNAVInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/MapWCFServiceWebRoleNAVInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WCFServiceWebRoleNAV:Endpoint1">
          <toPorts>
            <inPortMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAV/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWCFServiceWebRoleNAV:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAV/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWCFServiceWebRoleNAVInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAVInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WCFServiceWebRoleNAV" generation="1" functional="0" release="0" software="C:\STEFANO\CLOUD\NAVAzureCloudService\NAVAzureCloudService\csx\Release\roles\WCFServiceWebRoleNAV" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WCFServiceWebRoleNAV&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WCFServiceWebRoleNAV&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAVInstances" />
            <sCSPolicyUpdateDomainMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAVUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAVFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WCFServiceWebRoleNAVUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WCFServiceWebRoleNAVFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WCFServiceWebRoleNAVInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="bd1ff105-bc86-45e4-814f-de7936b26abd" ref="Microsoft.RedDog.Contract\ServiceContract\NAVAzureCloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="7e6a1495-682a-4c09-a957-3e50eefead1a" ref="Microsoft.RedDog.Contract\Interface\WCFServiceWebRoleNAV:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/NAVAzureCloudService/NAVAzureCloudServiceGroup/WCFServiceWebRoleNAV:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>