1.Restaurar nugets de la solución y compilarla.

2.Add this code in your WebJugueteria.csproj.user file:
<Target Name="CopyRoslynFiles" AfterTargets="AfterBuild" Condition="!$(Disable_CopyWebApplication) And '$(OutDir)' != '$(OutputPath)'">
    <ItemGroup>
      <RoslynFiles Include="$(CscToolPath)\*" />
    </ItemGroup>
    <MakeDir Directories="$(WebProjectOutputDir)\bin\roslyn" />
    <Copy SourceFiles="@(RoslynFiles)" DestinationFolder="$(WebProjectOutputDir)\bin\roslyn" SkipUnchangedFiles="true" Retries="$(CopyRetryCount)" RetryDelayMilliseconds="$(CopyRetryDelayMilliseconds)" />
</Target>

2.1 Cerrar Solución y volver a abrir para que tome cambios, limpiar y compilar nuevamente.

3.Configurar Solución MobileFood con los dos proyectos de inicio multiple con acción iniciar.

4.Configurar en Web.Config del proyecto WebTruckFood la llave ServiceUrl de la url de la api.

5.Iniciar la solución.