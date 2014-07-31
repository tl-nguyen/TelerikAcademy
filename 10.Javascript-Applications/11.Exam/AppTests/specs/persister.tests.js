define(['chai', 'persister'], function (chai, Persister){
    var expect = chai.expect;

    describe('#Persister', function () {
        var url = 'http://jsapps.bgcoder.com/',
            sessionKey = '',
            username = '',
            password = '';

        it('persister is created', function () {
            var persister = new Persister(url);

            expect(persister).to.be.ok;
        });

        it('persister is created without url', function () {
            expect(function () {
                new Persister();
            }).to.throw();
        });

        it('Register user', function (done) {
            var persister = new Persister(url);

            username = 'TL' + Math.floor((Math.random() * 1000));
            password = '123456';

            console.log(username);

            persister.user.register({
                username: username,
                password: password
            }).then(function (data) {
                    expect(data).to.be.ok;
                    done();
                });
        });
    });

});