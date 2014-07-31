define(['chai', 'controller'], function (chai, Controller){
    var expect = chai.expect;

    describe('#Controller', function () {

        var url = 'http://jsapps.bgcoder.com/';
        it('controller is created', function () {
            var controller = new Controller(url, '#blbla');

            expect(controller).to.be.ok;
        });

        it('controller is created without url', function () {
            expect(function () {
                new Controller();
            }).to.throw();
        });

        it('controller is created without selector', function () {
            expect(function () {
                new Controller(url);
            }).to.throw();
        });
    });

});