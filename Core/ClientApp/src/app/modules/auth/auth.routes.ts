export default {
    get: {
        checkIsLoggedIn: 'api/Authentication/CheckIsLoggedIn',
    },
    post: {
        login: 'api/Authentication/Login',
        logout: 'api/Authentication/Logout',
        register: 'api/Authentication/Register',
        loginOrRegisterExternal: 'api/Authentication/loginOrRegisterExternal',
    },
};
