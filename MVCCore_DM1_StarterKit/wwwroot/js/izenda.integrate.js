var DoIzendaConfig = function () {
    var hostApi = "http://localhost:4001/api/";
    var configJson = {
        "WebApiUrl": hostApi,
        "BaseUrl": "/izenda",
        "RootPath": "/js/izenda",
        "CssFile": "izenda-ui.css",
        "Routes": {
            "Settings": "settings",
            "New": "new",
            "Dashboard": "dashboard",
            "Report": "report",
            "ReportViewer": "reportviewer",
            "ReportViewerPopup": "reportviewerpopup",
            "Viewer": "viewer"
        },
        "Timeout": 3600,
        "OnReceiveUnauthorizedResponse": OnReceiveUnauthorizedResponse
    };
    IzendaSynergy.config(configJson);

};

function errorFunc() {
    // confirm dialog
    alertify.confirm("Your token was not generated correctly, please login.", function () {
        // user clicked "ok"
        window.location.href = "/Identity/Account/Login";
    }, function () {
        // user clicked "cancel"
        window.location.href = "/";
    });
}

//This function will be executed when a request receive an 401 response 
var OnReceiveUnauthorizedResponse = function (message) {
    //Redirect users back to their home page
    //location = location.protocol + '//' + location.host;
    //or custom page
    window.location.href = "/Identity/Account/AccessDenied";
};

var DoRender = function (successFunc) {
    $.ajax({
        type: "GET",
        url: "/user/GenerateToken",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });
};



var izendaInit = function () {
    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        var izendaRoot = document.getElementById('izenda-root');
        IzendaSynergy.unmountComponent(izendaRoot);
        IzendaSynergy.render(izendaRoot);
    }

    this.DoRender(successFunc);

};

var izendaInitReport = function () {

    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderReportPage(document.getElementById('izenda-root'));
    }

    this.DoRender(successFunc);

};

var izendaInitSetting = function () {

    function successFunc(data, status) {
        console.info(data);
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderSettingPage(document.getElementById('izenda-root'));
    }

    this.DoRender(successFunc);
};

var izendaInitMixedParts = function (allParts) {

    function successFunc(data, status) {
        console.info(data);
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);

        allParts.forEach(function (item, index) {
            var element = document.getElementById('izenda-part' + (index + 1));
            if (item.type === 'report') {
                IzendaSynergy.renderReportViewerPage(element, item.id);
            } else if (item.type === 'reportPart') {
                IzendaSynergy.renderReportPart(element, { id: item.id });
            } else {
                IzendaSynergy.renderDashboardViewerPage(element, item.id);
            }
        });

    }
    this.DoRender(successFunc);
}

// Render report parts to specific <div> tag by report part id
var izendaInitReportPartDemo = function () {

    function successFunc(data, status) {
        console.info(data);
        var currentUserContext = {
            token: data.token
        };

        // You can add report parts after creating reports using the context below
        // Add the report part ID's in the <add your report part id here> area
        // Please update the report part id with one created in your environment.
        // Updated ID not to show the report part instead of loading icon
        // Updated report part id's corresponds to QA DM1 env.
        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderReportPart(document.getElementById('izenda-report-part1'), {
            "id": "73cb2fd9-c0fd-457f-b5d7-7304f08f91f9",
        });

        IzendaSynergy.renderReportPart(document.getElementById('izenda-report-part2'), {
            "id": "b3e54979-375f-4dc8-9c05-d61850facd95",
        });

        IzendaSynergy.renderReportPart(document.getElementById('izenda-report-part3'), {
            "id": "b3e54979-375f-4dc8-9c05-d61850facd95"
        });
    }
    this.DoRender(successFunc);
};

// Render report viewer to a <div> tag by report id
var izendaInitReportViewer = function (reportId, filters) {
    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };
        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderReportViewerPage(document.getElementById('izenda-root'), reportId, filters);
    }

    this.DoRender(successFunc);

};

var izendaInitIframeViewer = function (reportId, filters) {
    IzendaSynergy.renderReportViewerPage(document.getElementById('izenda-root'), reportId, filters);
};

var izendaInitDashboard = function () {

    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderDashboardPage(document.getElementById('izenda-root'));
    }

    this.DoRender(successFunc);

};

// Render dashboard viewer to a <div> tag by dashboard id
var izendaInitDashboardViewer = function (dashboardId, filters) {
    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };
        IzendaSynergy.setCurrentUserContext(currentUserContext);
        var izendaRoot = document.getElementById('izenda-root');
        IzendaSynergy.unmountComponent(izendaRoot);
        IzendaSynergy.render(izendaRoot);
    }

    this.DoRender(successFunc);
};

var izendaInitReportDesigner = function () {

    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderReportDesignerPage(document.getElementById('izenda-root'));
    }

    this.DoRender(successFunc);

};

var izendaInitNewDashboard = function () {

    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        var izendaRoot = document.getElementById('izenda-root');
        IzendaSynergy.unmountComponent(izendaRoot);
        IzendaSynergy.renderNewDashboardPage(izendaRoot);
    }

    this.DoRender(successFunc);

};

// Render report part
var izendaInitReportPartViewer = function (reportPartId) {
    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };
        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderReportPart(document.getElementById('izenda-root'), {
            id: reportPartId
        });
    }

    this.DoRender(successFunc);

};

var izendaInitReportPartExportViewer = function (reportPartId, token) {
    var currentUserContext = {
        token: decodeURIComponent(token)
    };
    IzendaSynergy.setCurrentUserContext(currentUserContext);
    IzendaSynergy.renderReportPart(document.getElementById('izenda-root'), {
        id: reportPartId,
        useQueryParam: true,
        useHash: false
    });
};

var izendaInitMigrationManager = function () {
    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderMigrationManagerPage(document.getElementById('izenda-root'));
    }
    this.DoRender(successFunc);
};

var izendaInitRenderExportManagerPage = function () {
    function successFunc(data, status) {
        var currentUserContext = {
            token: data.token
        };

        IzendaSynergy.setCurrentUserContext(currentUserContext);
        IzendaSynergy.renderExportManagerPage(document.getElementById('izenda-root'));
    }
    this.DoRender(successFunc);
};
