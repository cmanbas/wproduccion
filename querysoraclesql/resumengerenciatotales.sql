SELECT 
      VersionData,
      Ngerente,
      AGerente,
      codinternogerencia,
      Gerencia,
      agno,
      'Rentas Brutas' AS tiporenta,
      Enero,
      Febrero,
      Marzo,
      Abril,
      Mayo,
      Junio,
      Julio,
      Agosto,
      Septiembre,
      Octubre,
      Noviembre,
      Diciembre,
      Total,
      CASE WHEN Total <> 0 THEN ROUND((Enero / Total) * 100, 2) ELSE 0 END AS P_Enero,
      CASE WHEN Total <> 0 THEN ROUND((Febrero / Total) * 100, 2) ELSE 0 END AS P_Febrero,
      CASE WHEN Total <> 0 THEN ROUND((Marzo / Total) * 100, 2) ELSE 0 END AS P_Marzo,
      CASE WHEN Total <> 0 THEN ROUND((Abril / Total) * 100, 2) ELSE 0 END AS P_Abril,
      CASE WHEN Total <> 0 THEN ROUND((Mayo / Total) * 100, 2) ELSE 0 END AS P_Mayo,
      CASE WHEN Total <> 0 THEN ROUND((Junio / Total) * 100, 2) ELSE 0 END AS P_Junio,
      CASE WHEN Total <> 0 THEN ROUND((Julio / Total) * 100, 2) ELSE 0 END AS P_Julio,
      CASE WHEN Total <> 0 THEN ROUND((Agosto / Total) * 100, 2) ELSE 0 END AS P_Agosto,
      CASE WHEN Total <> 0 THEN ROUND((Septiembre / Total) * 100, 2) ELSE 0 END AS P_Septiembre,
      CASE WHEN Total <> 0 THEN ROUND((Octubre / Total) * 100, 2) ELSE 0 END AS P_Octubre,
      CASE WHEN Total <> 0 THEN ROUND((Noviembre / Total) * 100, 2) ELSE 0 END AS P_Noviembre,
      CASE WHEN Total <> 0 THEN ROUND((Diciembre / Total) * 100, 2) ELSE 0 END AS P_Diciembre,
      'Personal' AS personal,
      CEnero,
      CFebrero,
      CMarzo,
      CAbril,
      CMayo,
      CJunio,
      CJulio,
      CAgosto,
      CSeptiembre,
      COctubre,
      CNoviembre,
      CDiciembre,
      cTotal,
      CASE WHEN cTotal <> 0 THEN ROUND((CEnero / cTotal) * 100, 3) ELSE 0 END AS Pc_enero,
      CASE WHEN cTotal <> 0 THEN ROUND((CFebrero / cTotal) * 100, 3) ELSE 0 END AS Pc_Febrero,
      CASE WHEN cTotal <> 0 THEN ROUND((CMarzo / cTotal) * 100, 3) ELSE 0 END AS Pc_Marzo,
      CASE WHEN cTotal <> 0 THEN ROUND((CAbril / cTotal) * 100, 3) ELSE 0 END AS Pc_Abril,
      CASE WHEN cTotal <> 0 THEN ROUND((CMayo / cTotal) * 100, 3) ELSE 0 END AS Pc_Mayo,
      CASE WHEN cTotal <> 0 THEN ROUND((CJunio / cTotal) * 100, 3) ELSE 0 END AS Pc_Junio,
      CASE WHEN cTotal <> 0 THEN ROUND((CJulio / cTotal) * 100, 3) ELSE 0 END AS Pc_Julio,
      CASE WHEN cTotal <> 0 THEN ROUND((CAgosto / cTotal) * 100, 3) ELSE 0 END AS Pc_Agosto,
      CASE WHEN cTotal <> 0 THEN ROUND((CSeptiembre / cTotal) * 100, 3) ELSE 0 END AS Pc_Septiembre,
      CASE WHEN cTotal <> 0 THEN ROUND((COctubre / cTotal) * 100, 3) ELSE 0 END AS Pc_Octubre,
      CASE WHEN cTotal <> 0 THEN ROUND((CNoviembre / cTotal) * 100, 3) ELSE 0 END AS Pc_Noviembre,
      CASE WHEN cTotal <> 0 THEN ROUND((CDiciembre / cTotal) * 100, 3) ELSE 0 END AS Pc_Diciembre
  FROM v_gerencia_totales
  WHERE versiondata = 1 AND agno = 2024

UNION ALL

SELECT 
      VersionData,
      Ngerente,
      AGerente,
      codinternogerencia,
      Gerencia,
      agno,
      'Rentas Brutas' AS tiporenta,
      Enero,
      Febrero,
      Marzo,
      Abril,
      Mayo,
      Junio,
      Julio,
      Agosto,
      Septiembre,
      Octubre,
      Noviembre,
      Diciembre,
      Total,
      CASE WHEN Total <> 0 THEN ROUND((Enero / Total) * 100, 2) ELSE 0 END AS P_Enero,
      CASE WHEN Total <> 0 THEN ROUND((Febrero / Total) * 100, 2) ELSE 0 END AS P_Febrero,
      CASE WHEN Total <> 0 THEN ROUND((Marzo / Total) * 100, 2) ELSE 0 END AS P_Marzo,
      CASE WHEN Total <> 0 THEN ROUND((Abril / Total) * 100, 2) ELSE 0 END AS P_Abril,
      CASE WHEN Total <> 0 THEN ROUND((Mayo / Total) * 100, 2) ELSE 0 END AS P_Mayo,
      CASE WHEN Total <> 0 THEN ROUND((Junio / Total) * 100, 2) ELSE 0 END AS P_Junio,
      CASE WHEN Total <> 0 THEN ROUND((Julio / Total) * 100, 2) ELSE 0 END AS P_Julio,
      CASE WHEN Total <> 0 THEN ROUND((Agosto / Total) * 100, 2) ELSE 0 END AS P_Agosto,
      CASE WHEN Total <> 0 THEN ROUND((Septiembre / Total) * 100, 2) ELSE 0 END AS P_Septiembre,
      CASE WHEN Total <> 0 THEN ROUND((Octubre / Total) * 100, 2) ELSE 0 END AS P_Octubre,
      CASE WHEN Total <> 0 THEN ROUND((Noviembre / Total) * 100, 2) ELSE 0 END AS P_Noviembre,
      CASE WHEN Total <> 0 THEN ROUND((Diciembre / Total) * 100, 2) ELSE 0 END AS P_Diciembre,
      'Personal' AS personal,
      CEnero,
      CFebrero,
      CMarzo,
      CAbril,
      CMayo,
      CJunio,
      CJulio,
      CAgosto,
      CSeptiembre,
      COctubre,
      CNoviembre,
      CDiciembre,
      cTotal,
      CASE WHEN cTotal <> 0 THEN ROUND((CEnero / cTotal) * 100, 3) ELSE 0 END AS Pc_enero,
      CASE WHEN cTotal <> 0 THEN ROUND((CFebrero / cTotal) * 100, 3) ELSE 0 END AS Pc_Febrero,
      CASE WHEN cTotal <> 0 THEN ROUND((CMarzo / cTotal) * 100, 3) ELSE 0 END AS Pc_Marzo,
      CASE WHEN cTotal <> 0 THEN ROUND((CAbril / cTotal) * 100, 3) ELSE 0 END AS Pc_Abril,
      CASE WHEN cTotal <> 0 THEN ROUND((CMayo / cTotal) * 100, 3) ELSE 0 END AS Pc_Mayo,
      CASE WHEN cTotal <> 0 THEN ROUND((CJunio / cTotal) * 100, 3) ELSE 0 END AS Pc_Junio,
      CASE WHEN cTotal <> 0 THEN ROUND((CJulio / cTotal) * 100, 3) ELSE 0 END AS Pc_Julio,
      CASE WHEN cTotal <> 0 THEN ROUND((CAgosto / cTotal) * 100, 3) ELSE 0 END AS Pc_Agosto,
      CASE WHEN cTotal <> 0 THEN ROUND((CSeptiembre / cTotal) * 100, 3) ELSE 0 END AS Pc_Septiembre,
      CASE WHEN cTotal <> 0 THEN ROUND((COctubre / cTotal) * 100, 3) ELSE 0 END AS Pc_Octubre,
      CASE WHEN cTotal <> 0 THEN ROUND((CNoviembre / cTotal) * 100, 3) ELSE 0 END AS Pc_Noviembre,
      CASE WHEN cTotal <> 0 THEN ROUND((CDiciembre / cTotal) * 100, 3) ELSE 0 END AS Pc_Diciembre
  FROM v_gerencia_totales
  WHERE versiondata = 1 AND agno = 2025

ORDER BY VersionData,
      Ngerente,
      AGerente,
      codinternogerencia,
      Gerencia,
      agno;