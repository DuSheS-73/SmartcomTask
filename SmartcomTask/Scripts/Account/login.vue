<template>
    <div class="login">
        <form :action="LoginUrl" method="post">
            <div class="form-group">
                <label for="Username" class="form-label">Логин</label>
                <input name="Username" class="form-input" required/>
            </div>
            <div class="form-group">
                <label for="Password" class="form-label">Пароль</label>
                <input name="Password" type="password" class="form-input" required/>
            </div>
            <div class="form-group">                
                <input type="submit" value="Войти" class="form-submit-btn" />
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        props: {
            LoginUrl: String
        }
    };
</script>