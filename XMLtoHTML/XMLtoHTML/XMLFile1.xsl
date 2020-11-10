<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output
    method="html"></xsl:output>

    <xsl:template match="/">
      <html>
        <body>
          <table border ="1">
            <TR>
              <th>Name</th>
              <th>Faculty</th>
              <th>Group</th>
              <th>Subject</th>
              <th>Mark</th>
            </TR>
            <xsl:for-each select="Students/Student">
              <tr>
                <td>
                  <xsl:value-of select="@Name"/>
                </td>
                <td>
                  <xsl:value-of select="@Faculty"/>
                </td>
                <td>
                  <xsl:value-of select="@Group"/>
                </td>
                <td>
                  <xsl:value-of select="@Subject"/>
                </td>
                <td>
                  <xsl:value-of select="@Mark"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
