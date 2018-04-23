@ModelType List(Of Sample.Models.Person)
@Code
    Dim needCreatCopy As Boolean = ViewData("key") IsNot Nothing
End Code
@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            settings.KeyFieldName = "PersonID"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewEditingPartial"}
            settings.CustomActionRouteValues = New With {.Controller = "Home", .Action = "CustomGridViewEditingPartial"}


            settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "EditingAddNew"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "EditingUpdate"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "EditingDelete"}

            settings.CommandColumn.Visible = True
            settings.CommandColumn.NewButton.Visible = True
            settings.CommandColumn.DeleteButton.Visible = True
            settings.CommandColumn.EditButton.Visible = True
            settings.CommandColumn.CustomButtons.Add(New GridViewCommandColumnCustomButton() With {.ID = "btnCopy", .Text = "Copy"})

            settings.ClientSideEvents.BeginCallback = "OnBeginCallback"
            settings.ClientSideEvents.CustomButtonClick = "OnCustomButtonClick"

            settings.Columns.Add("FirstName")
            settings.Columns.Add("MiddleName")
            settings.Columns.Add("LastName")

            settings.InitNewRow = _
                Sub(sender, e)
                        If needCreatCopy Then
                            Dim keyValue As Object = ViewData("key")

                            Dim gridView As MVCxGridView = CType(sender, MVCxGridView)
                            Dim rowValues() As Object = CType(gridView.GetRowValuesByKeyValue(keyValue, New String() {"FirstName", "MiddleName", "LastName"}), Object())

                            e.NewValues("FirstName") = rowValues(0)
                            e.NewValues("MiddleName") = rowValues(1)
                            e.NewValues("LastName") = rowValues(2)
                        End If
                End Sub

            settings.BeforeGetCallbackResult = _
                Sub(sender, e)
                        If (needCreatCopy) Then
                            CType(sender, MVCxGridView).AddNewRow()
                        End If
                End Sub

    End Sub).Bind(Model).GetHtml()