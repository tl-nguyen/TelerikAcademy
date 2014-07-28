define(['chai', 'persisters'], function (chai, persisters){
    var expect = chai.expect;

    describe('#Persisters', function () {
        it('persister is created', function () {
            var persister = persisters.get('fdsaf');
            expect(persister).to.be.ok;
        });

        it('persister is created without url', function () {
            var persister = persisters.get();
            expect(persister.rootUrl).to.be.undefined;
        });

        it('if user is logged in , function nickname should return user\'s nickname', function () {
            var persister = persisters.get();
            persister.chatRoom.loggedIn('TL');
            expect(persister.nickname()).to.be.eql('TL');
        });
    });

});