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
        stage('build-app1') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose build app1'
            }
        }

        stage('build-app2') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose build app2'
            }
        }

        stage('run-test') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose build tests'
            }
        }

        stage('docker-login') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker login localhost:8082 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
                sh 'docker login localhost:8083 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
                sh 'docker login localhost:8084 -u $NEXUS_USERNAME -p $NEXUS_PASSWORD'
            }
        }

        stage('push-to-nexus') {
            agent {
                label 'ag-default'
            }
            steps {
                sh 'docker compose push'
            }
        }

        stage('deploy') {
             agent {
                label 'ag-default'
            }
            steps {
                sh 'kubectl apply -f ./manifests/'
            }
        }
    }
}
