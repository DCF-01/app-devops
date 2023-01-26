pipeline {
    triggers {
        pollSCM('* * * * *')
    }
    agent {
        label 'ag-default'
    }
    environment {
        NEXUS_USERNAME = credentials('nexus-username')
        NEXUS_PASSWORD = credentials('nexus-password')
    }

    stages {
        stage('run-test') {
            steps {
                sh 'docker-compose build tests'
            }
        }

        stage('build-app1') {
            steps {
                sh 'docker-compose build app1'
            }
        }

        stage('build-app2') {
            steps {
                sh 'docker-compose build app2'
            }
        }

        stage('docker-login') {
            steps {
                sh 'docker login localhost:8082 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
            }
        }

        stage('push-to-nexus') {
            steps {
                sh 'docker-compose push'
            }
        }

        stage('deploy') {
            steps {
                sh 'kubectl apply -f ./manifests/'
            }
        }
    }
}
